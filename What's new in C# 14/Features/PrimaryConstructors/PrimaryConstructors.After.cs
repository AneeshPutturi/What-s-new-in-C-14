namespace What_s_new_in_C__14.Features.PrimaryConstructors;

// Today: primary constructor captures values in the signature.
public sealed class Order(int Id, decimal Amount)
{
    public int Id { get; } = Id;
    public decimal Amount { get; } = Amount;
}

