using System;

namespace What_s_new_in_C__14.Features.RefReadonlyParameters;

// ❌ Prior pattern: copy to array to avoid mutation but pay allocation.
public static class RefReadonlyParameters_Before
{
    public static double Mean(int[] source)
    {
        // Defensive copy to avoid caller mutation affecting mean.
        var copy = (int[])source.Clone();
        long total = 0;
        foreach (var v in copy) total += v;
        return (double)total / copy.Length;
    }
}

