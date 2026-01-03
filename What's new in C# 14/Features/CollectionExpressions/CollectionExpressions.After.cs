using System.Collections.Generic;

namespace What_s_new_in_C__14.Features.CollectionExpressions;

// ✅ Introduced in C# 12 (baseline for comparison): unified [] literal with spread.
public static class CollectionExpressions_After
{
    public static List<int> Build() => [.. new[] { 1, 2 }, .. new[] { 3, 4 }];
}

