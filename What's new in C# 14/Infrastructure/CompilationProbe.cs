using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using What_s_new_in_C__14.Features;

namespace What_s_new_in_C__14.Infrastructure;

internal sealed record CompileOutcome(LanguageVersion Version, bool Success, string? ErrorId, string? ErrorMessage);

internal sealed record ProbeResult(
    string Feature,
    CompileOutcome Cs12,
    CompileOutcome Cs13,
    CompileOutcome Preview,
    FeatureStatus Status);

internal static class CompilationProbe
{
    public static ProbeResult Probe(string featureName, string code)
    {
        var cs12 = Compile(featureName, code, LanguageVersion.CSharp12);
        var cs13 = Compile(featureName, code, LanguageVersion.CSharp13);
        var preview = Compile(featureName, code, LanguageVersion.Preview);

        var status = Classify(cs12, cs13, preview);

        return new ProbeResult(featureName, cs12, cs13, preview, status);
    }

    private static FeatureStatus Classify(CompileOutcome cs12, CompileOutcome cs13, CompileOutcome preview)
    {
        if (!cs12.Success && !cs13.Success && preview.Success)
        {
            return FeatureStatus.PreviewCSharp14;
        }

        if (cs12.Success || cs13.Success)
        {
            return FeatureStatus.BaselineEarlier;
        }

        return FeatureStatus.Removed;
    }

    private static CompileOutcome Compile(string featureName, string code, LanguageVersion version)
    {
        var parseOptions = new CSharpParseOptions(languageVersion: version);
        var syntaxTree = CSharpSyntaxTree.ParseText(code, parseOptions);

        var references = ReferenceCache.Value;
        var compilation = CSharpCompilation.Create(
            assemblyName: $"Proof_{featureName}_{version}",
            syntaxTrees: new[] { syntaxTree },
            references: references,
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        using var ms = new MemoryStream();
        var emitResult = compilation.Emit(ms);

        if (emitResult.Success)
        {
            return new CompileOutcome(version, true, null, null);
        }

        var diag = emitResult.Diagnostics.FirstOrDefault(d => d.Severity == DiagnosticSeverity.Error);
        return new CompileOutcome(
            version,
            false,
            diag?.Id ?? "UNKNOWN",
            diag?.GetMessage() ?? "Compilation failed");
    }

    private static readonly Lazy<IReadOnlyList<MetadataReference>> ReferenceCache = new(() =>
    {
        var assemblyPaths = (AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES") as string ?? string.Empty)
            .Split(Path.PathSeparator)
            .Where(p => p.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
            .ToList();

        string[] required =
        {
            "System.Private.CoreLib.dll",
            "System.Runtime.dll",
            "System.Console.dll",
            "System.Linq.dll",
            "System.Collections.dll",
            "System.Collections.Concurrent.dll",
            "System.Private.Uri.dll"
        };

        var selected = assemblyPaths
            .Where(p => required.Any(r => p.EndsWith(r, StringComparison.OrdinalIgnoreCase)))
            .Distinct()
            .Select(p => MetadataReference.CreateFromFile(p))
            .Cast<MetadataReference>()
            .ToList();

        // Fallback to include mscorlib-like reference if not already present.
        var coreLibPath = assemblyPaths.FirstOrDefault(p => p.EndsWith("System.Private.CoreLib.dll", StringComparison.OrdinalIgnoreCase));
        if (coreLibPath is not null && selected.All(r => !string.Equals(((PortableExecutableReference)r).FilePath, coreLibPath, StringComparison.OrdinalIgnoreCase)))
        {
            selected.Add(MetadataReference.CreateFromFile(coreLibPath));
        }

        return selected;
    });
}

