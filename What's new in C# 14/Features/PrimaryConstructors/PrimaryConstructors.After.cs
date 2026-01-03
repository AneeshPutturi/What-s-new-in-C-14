namespace What_s_new_in_C__14.Features.PrimaryConstructors;

// ✅ Works in C# 14 (preview): primary constructor directly on a class.
public sealed class ProvisioningJob(string WorkStream, decimal HourlyRate, string Region)
{
    private readonly decimal _hourlyRate = HourlyRate;

    public string WorkStream { get; } = WorkStream;
    public string Region { get; } = Region;

    public decimal EstimateCost(int hours)
    {
        var baseCost = hours * _hourlyRate;
        var overtime = hours > 8 ? (hours - 8) * _hourlyRate * 0.5m : 0m;
        return baseCost + overtime;
    }

    public override string ToString() => $"{WorkStream} in {Region} @ {_hourlyRate:C}/h";
}

