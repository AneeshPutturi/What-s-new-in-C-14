namespace What_s_new_in_C__14.Features.TypeAliases;

// Older tuple usage without alias — readable but repeated.
public static class TypeAliases_Before
{
    public static (int Id, string Name) MakeKey() => (101, "Sample user");
}

