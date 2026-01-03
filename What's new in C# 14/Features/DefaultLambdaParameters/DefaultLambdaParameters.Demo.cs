using System.Collections.Generic;
using What_s_new_in_C__14.Features;

namespace What_s_new_in_C__14.Features.DefaultLambdaParameters;

public sealed class DefaultLambdaParametersDemo : IFeatureDemo
{
    public string Title => "Default parameters on lambdas";
    public string Description =>
        "Earlier we wrote helper methods to fake defaults. Today lambdas can declare default values directly.";

    public IEnumerable<string> Run()
    {
        var beforeAdder = DefaultLambdaParameters_Before.MakeAdderWithDefault();
        var afterAdder = DefaultLambdaParameters_After.Add;

        yield return "Before:";
        yield return $"add(5) => {beforeAdder(5)} (needed wrapper)";

        yield return "After:";
        yield return $"add(5) => {afterAdder(5)}";
        yield return $"add(5, 2) => {afterAdder(5, 2)}";
    }
}

