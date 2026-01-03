namespace What_s_new_in_C__14.Features.DefaultLambdaParameters;

// Modern style: default parameter values directly on a lambda.
public delegate int Adder(int value, int bonus = 10);

public static class DefaultLambdaParameters_After
{
    public static Adder Add = (int value, int bonus = 10) => value + bonus;
}

