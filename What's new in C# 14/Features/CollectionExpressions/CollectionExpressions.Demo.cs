using System.Collections.Generic;
using System.Linq;
using What_s_new_in_C__14.Features;

namespace What_s_new_in_C__14.Features.CollectionExpressions;

public sealed class CollectionExpressionsDemo : IFeatureDemo
{
    public string Title => "Collection expressions + spread";
    public FeatureStatus Status => FeatureStatus.BaselineEarlier; // C# 12 feature; shown as baseline.
    public string Description =>
        "Baseline comparison: collection expressions shipped in C# 12. Included to contrast with C# 14 preview items.";

    public IEnumerable<string> Run()
    {
        List<int> before = CollectionExpressions_Before.Build();
        List<int> after = CollectionExpressions_After.Build();

        yield return "Before (C# <=12): AddRange/Concat required.";
        yield return $"Result: {string.Join(", ", before)}";

        yield return "After (C# 12): [] literal with spread (..).";
        yield return $"Result: {string.Join(", ", after)}";
    }
}

