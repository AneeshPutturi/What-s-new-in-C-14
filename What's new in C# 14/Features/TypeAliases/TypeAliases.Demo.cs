using System.Collections.Generic;
using What_s_new_in_C__14.Features;

namespace What_s_new_in_C__14.Features.TypeAliases;

public sealed class TypeAliasesDemo : IFeatureDemo
{
    public string Title => "Alias any type (tuples included)";
    public FeatureStatus Status => FeatureStatus.BaselineEarlier; // C# 12 feature; kept as baseline.
    public string Description =>
        "Baseline: C# 12 allowed aliasing any type, including tuples. Included here for comparison.";

    public IEnumerable<string> Run()
    {
        var before = TypeAliases_Before.MakeKey();
        var after = TypeAliases_After.MakeKey();

        yield return "Before (C# <=12): raw tuple in signatures.";
        yield return $"Value: {before.Service}/{before.Region}";

        yield return "After (C# 12): tuple is aliased for readability.";
        yield return $"Value: {after.Service}/{after.Region}";
    }
}

