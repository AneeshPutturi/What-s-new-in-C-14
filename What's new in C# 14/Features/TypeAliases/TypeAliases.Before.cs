namespace What_s_new_in_C__14.Features.TypeAliases;

// Older tuple usage without alias — readable but noisy.
public static class TypeAliases_Before
{
    public static (string Service, string Region) MakeKey() => ("payments", "us-east");
}

