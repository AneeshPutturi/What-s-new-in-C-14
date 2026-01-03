using System.Collections.Generic;
using System.Linq;
using What_s_new_in_C__14.Features;

namespace What_s_new_in_C__14.Features.CollectionExpressions;

public sealed class CollectionExpressionsDemo : IFeatureDemo
{
    public string Title => "Collection expressions + spread";
    public string Description =>
        "Earlier we added items step by step. Today [] with spread builds the list in one line.";

    public IEnumerable<string> Run()
    {
        List<int> before = CollectionExpressions_Before.Build();
        List<int> after = CollectionExpressions_After.Build();

        yield return "Before:";
        yield return $"Numbers built with AddRange => {string.Join(", ", before)}";

        yield return "After:";
        yield return $"Numbers built with [] and spread => {string.Join(", ", after)}";
    }
}

