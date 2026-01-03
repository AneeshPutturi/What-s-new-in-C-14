using System.Collections.Generic;
using System.Globalization;
using What_s_new_in_C__14.Features;

namespace What_s_new_in_C__14.Infrastructure;

internal static class ProofPrinter
{
    public static IEnumerable<string> FormatBuildInfo()
    {
        yield return "[Build Info]";
        yield return $"SDK: {BuildInfo.SdkVersion}";
        yield return $"TFM: {BuildInfo.TargetFramework}";
        yield return $"LangVersion: {BuildInfo.LangVersion}";
        yield return $"Runtime: {BuildInfo.RuntimeDescription}";
        yield return string.Empty;
    }

    public static IEnumerable<string> FormatMatrix(ProbeResult result)
    {
        yield return "[Compatibility Matrix]";
        yield return $"Feature: {result.Feature}";
        yield return FormatOutcome("C#12", result.Cs12);
        yield return FormatOutcome("C#13", result.Cs13);
        yield return FormatOutcome("Preview", result.Preview);
        yield return $"Classification: {result.Status}";
    }

    public static string FormatOutcome(string label, CompileOutcome outcome)
    {
        if (outcome.Success)
        {
            return $"{label}: PASS";
        }

        return $"{label}: FAIL ({outcome.ErrorId}: {outcome.ErrorMessage})";
    }
}

