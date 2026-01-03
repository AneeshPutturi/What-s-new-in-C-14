using System.Collections.Generic;

namespace What_s_new_in_C__14.Features;

public enum FeatureStatus
{
    FinalCSharp14,
    PreviewCSharp14,
    BaselineEarlier
}

public interface IFeatureDemo
{
    string Title { get; }
    FeatureStatus Status { get; }
    string Description { get; }
    IEnumerable<string> Run();
}

