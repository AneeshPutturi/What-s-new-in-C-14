using System.Collections.Generic;
using What_s_new_in_C__14.Features;

namespace What_s_new_in_C__14.Features.DefaultLambdaParameters;

public sealed class DefaultLambdaParametersDemo : IFeatureDemo
{
    public string Title => "Default parameters on lambdas";
    public FeatureStatus Status => FeatureStatus.BaselineEarlier; // C# 12 feature; kept for contrast.
    public string Description =>
        "Baseline: C# 12 added defaults on lambdas. Shown to contrast with true C# 14 preview items.";

    public IEnumerable<string> Run()
    {
        var beforeAdder = DefaultLambdaParameters_Before.MakeAdderWithDefault();
        var afterAdder = DefaultLambdaParameters_After.Add;

        yield return "Before (C# <=12): had to wrap to simulate defaults.";
        yield return $"Add(5) => {beforeAdder(5)}";

        yield return "After (C# 12): defaults declared inline on the lambda.";
        yield return $"Add(5) => {afterAdder(5)}";
        yield return $"Add(5, 2) => {afterAdder(5, 2)}";
    }
}

