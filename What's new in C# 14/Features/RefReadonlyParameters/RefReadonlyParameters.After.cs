using System;

namespace What_s_new_in_C__14.Features.RefReadonlyParameters;

// ✅ Preview framing: ref readonly parameters usable in more contexts without overloads.
public static class RefReadonlyParameters_After
{
    public static double Mean(in ReadOnlySpan<int> source)
    {
        long total = 0;
        foreach (var v in source) total += v;
        return (double)total / source.Length;
    }
}

