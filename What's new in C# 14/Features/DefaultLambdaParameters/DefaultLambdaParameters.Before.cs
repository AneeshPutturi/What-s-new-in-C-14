namespace What_s_new_in_C__14.Features.DefaultLambdaParameters;

// ❌ Older style: helper wrapper needed to simulate defaults on lambdas.
public static class DefaultLambdaParameters_Before
{
    public static Func<int, int> MakeAdderWithDefault() => (v) => Add(v, 10);

    private static int Add(int value, int bonus) => value + bonus;
}

