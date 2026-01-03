using System;
using System.Collections.Generic;
using What_s_new_in_C__14.Features;
using What_s_new_in_C__14.Features.CollectionExpressions;
using What_s_new_in_C__14.Features.DefaultLambdaParameters;
using What_s_new_in_C__14.Features.PrimaryConstructors;
using What_s_new_in_C__14.Features.RefReadonlyParameters;
using What_s_new_in_C__14.Features.TypeAliases;
using What_s_new_in_C__14.Infrastructure;

namespace What_s_new_in_C__14;

internal static class Program
{
    private static void Main()
    {
        foreach (var line in ProofPrinter.FormatBuildInfo())
        {
            Console.WriteLine(line);
        }

        var demos = new IFeatureDemo[]
        {
            new PrimaryConstructorsDemo(),
            new CollectionExpressionsDemo(),
            new DefaultLambdaParametersDemo(),
            new RefReadonlyParametersDemo(),
            new TypeAliasesDemo(),
        };

        Console.WriteLine("C# 14 feature audit with compiler proofs");
        Console.WriteLine("---------------------------------------\n");

        foreach (var demo in demos)
        {
            PrintSection(demo);
        }
    }

    private static void PrintSection(IFeatureDemo demo)
    {
        Console.WriteLine($"=== {demo.Title} [{demo.Status}] ===");
        Console.WriteLine(demo.Description);
        foreach (var line in demo.Run())
        {
            Console.WriteLine($"• {line}");
        }

        Console.WriteLine();
    }
}
