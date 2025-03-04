using Lab9_1;

namespace Lab10;

public class NameLengthComparer : IComparer<IInit>
{
    public int Compare(IInit? x, IInit? y)
    {
        return x.Name.Length.CompareTo(y.Name.Length);
    }
}