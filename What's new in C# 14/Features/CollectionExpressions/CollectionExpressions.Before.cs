using System.Collections.Generic;

namespace What_s_new_in_C__14.Features.CollectionExpressions;

// ❌ Older style (C# <=12): manual AddRange/Concat boilerplate.
public static class CollectionExpressions_Before
{
    public static List<int> Build()
    {
        var list = new List<int>();
        list.AddRange(new[] { 1, 2 });
        list.AddRange(new[] { 3, 4 });
        return list;
    }
}

