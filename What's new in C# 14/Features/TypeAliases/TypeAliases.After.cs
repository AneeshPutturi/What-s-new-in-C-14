namespace What_s_new_in_C__14.Features.TypeAliases;

// ✅ Introduced in C# 12 (baseline): alias any type, including tuples.
using ServiceKey = (string Service, string Region);

public static class TypeAliases_After
{
    public static ServiceKey MakeKey() => new("payments", "us-east");
}

