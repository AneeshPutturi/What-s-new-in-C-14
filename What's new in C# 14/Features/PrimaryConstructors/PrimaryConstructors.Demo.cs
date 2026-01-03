using System.Collections.Generic;
using What_s_new_in_C__14.Features;

namespace What_s_new_in_C__14.Features.PrimaryConstructors;

public sealed class PrimaryConstructorsDemo : IFeatureDemo
{
    public string Title => "Primary constructors — cleaner object initialization";
    public string Description =>
        "Earlier we wrote constructor bodies to copy values. Today the class signature can hold them directly.";

    public IEnumerable<string> Run()
    {
        var before = new Order_Before(101, 250.75m);
        var after = new Order(101, 250.75m);

        yield return "Before:";
        yield return $"Order {before.Id} amount {before.Amount} (constructor + assignments)";

        yield return "After:";
        yield return $"Order {after.Id} amount {after.Amount} (captured in the signature)";
    }
}

