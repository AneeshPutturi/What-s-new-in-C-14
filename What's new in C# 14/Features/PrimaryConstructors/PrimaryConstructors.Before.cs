namespace What_s_new_in_C__14.Features.PrimaryConstructors;

// Earlier: constructor plus manual assignments.
public sealed class Order_Before
{
    public int Id { get; }
    public decimal Amount { get; }

    public Order_Before(int id, decimal amount)
    {
        Id = id;
        Amount = amount;
    }
}

