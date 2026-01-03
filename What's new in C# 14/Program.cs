using System;
using System.Collections.Generic;
using What_s_new_in_C__14.Features;
using What_s_new_in_C__14.Features.CollectionExpressions;
using What_s_new_in_C__14.Features.DefaultLambdaParameters;
using What_s_new_in_C__14.Features.PrimaryConstructors;
using What_s_new_in_C__14.Features.TypeAliases;

namespace What_s_new_in_C__14;

internal static class Program
{
    private static void Main()
    {
        var demos = new IFeatureDemo[]
        {
            new PrimaryConstructorsDemo(),
            new CollectionExpressionsDemo(),
            new DefaultLambdaParametersDemo(),
            new TypeAliasesDemo(),
        };

        Console.WriteLine("Modern C# (C# 14 era) — Before/After");
        Console.WriteLine("------------------------------------\n");

        foreach (var demo in demos)
        {
            PrintSection(demo);
        }
    }

    private static void PrintSection(IFeatureDemo demo)
    {
        Console.WriteLine($"=== {demo.Title} ===");
        Console.WriteLine(demo.Description);
        foreach (var line in demo.Run())
        {
            Console.WriteLine($"• {line}");
        }

        Console.WriteLine();
    }
}
