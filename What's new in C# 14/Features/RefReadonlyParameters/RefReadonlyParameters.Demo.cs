using System;
using System.Collections.Generic;
using System.Globalization;
using What_s_new_in_C__14.Features;

namespace What_s_new_in_C__14.Features.RefReadonlyParameters;

public sealed class RefReadonlyParametersDemo : IFeatureDemo
{
    public string Title => "Ref readonly parameters (wider use)";
    public FeatureStatus Status => FeatureStatus.PreviewCSharp14;
    public string Description =>
        "Preview framing: ref readonly parameters are usable in more call patterns, reducing defensive copies while preventing mutation.";

    public IEnumerable<string> Run()
    {
        int[] data = [4, 8, 15, 16, 23, 42];

        var beforeMean = RefReadonlyParameters_Before.Mean(data);
        var afterMean = RefReadonlyParameters_After.Mean(data.AsSpan()); // safe, no copy

        yield return "Before (defensive copy to avoid caller mutation).";
        yield return $"Mean = {beforeMean.ToString("F2", CultureInfo.InvariantCulture)}";

        yield return "After (ref readonly flow, no allocation, mutation prevented).";
        yield return $"Mean = {afterMean.ToString("F2", CultureInfo.InvariantCulture)}";
    }
}

