using System.Collections.Generic;
using What_s_new_in_C__14.Features;

namespace What_s_new_in_C__14.Features.TypeAliases;

public sealed class TypeAliasesDemo : IFeatureDemo
{
    public string Title => "Alias any type (tuples included)";
    public string Description =>
        "Earlier we repeated tuple shapes in many places. Today an alias keeps the intent short.";

    public IEnumerable<string> Run()
    {
        var before = TypeAliases_Before.MakeKey();
        var after = TypeAliases_After.MakeKey();

        yield return "Before:";
        yield return $"Raw tuple => {before.Id}/{before.Name}";

        yield return "After:";
        yield return $"Aliased tuple => {after.Id}/{after.Name}";
    }
}

