using System.Collections.Generic;
using What_s_new_in_C__14.Features;
using What_s_new_in_C__14.Infrastructure;

namespace What_s_new_in_C__14.Features.PrimaryConstructors;

public sealed class PrimaryConstructorsDemo : IFeatureDemo
{
    public string Title => "Primary constructors on classes";
    public FeatureStatus Status => _probe.Status;
    public string Description => "Classes with primary constructors. Expected to fail C#12/13 and pass preview.";

    private static readonly ProbeResult _probe = CompilationProbe.Probe(
        "PrimaryConstructorsOnClasses",
        """
        public class Widget(string Name)
        {
            public string Name { get; } = Name;
        }
        """);

    public IEnumerable<string> Run()
    {
        foreach (var line in ProofPrinter.FormatMatrix(_probe))
            yield return line;

        yield return "[Before] Requires manual ctor; primary constructor syntax rejected in C#12/13.";
        yield return $"C#13 compile: {ProofPrinter.FormatOutcome("C#13", _probe.Cs13)}";
        yield return "[After] Primary constructor form accepted.";
        yield return $"Preview compile: {ProofPrinter.FormatOutcome("Preview", _probe.Preview)}";
    }
}

