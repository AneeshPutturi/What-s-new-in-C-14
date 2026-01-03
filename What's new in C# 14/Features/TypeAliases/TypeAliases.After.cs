namespace What_s_new_in_C__14.Features.TypeAliases;

// Modern style: alias any type, including tuples, for readability.
using PersonId = (int Id, string Name);

public static class TypeAliases_After
{
    public static PersonId MakeKey() => new(101, "Sample user");
}

