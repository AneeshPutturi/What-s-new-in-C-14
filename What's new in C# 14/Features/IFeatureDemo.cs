using System.Collections.Generic;

namespace What_s_new_in_C__14.Features;

public interface IFeatureDemo
{
    string Title { get; }
    string Description { get; }
    IEnumerable<string> Run();
}

