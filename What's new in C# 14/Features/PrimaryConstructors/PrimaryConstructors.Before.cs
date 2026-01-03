namespace What_s_new_in_C__14.Features.PrimaryConstructors;

// ❌ Not possible before C# 14:
// primary constructors on classes were only for records/structs.
public sealed class ProvisioningJob_Before
{
    public string WorkStream { get; }
    public decimal HourlyRate { get; }
    public string Region { get; }

    public ProvisioningJob_Before(string workStream, decimal hourlyRate, string region)
    {
        WorkStream = workStream;
        HourlyRate = hourlyRate;
        Region = region;
    }

    public decimal EstimateCost(int hours)
    {
        var baseCost = hours * HourlyRate;
        var overtime = hours > 8 ? (hours - 8) * HourlyRate * 0.5m : 0m;
        return baseCost + overtime;
    }
}

