using GridProblem.Services;

namespace GridProblem.Comparers;

public class ClassifiedGridPointComparer : IEqualityComparer<ClassifiedGridPoint>
{
    private const double FloatingPointComparisonTolerance = 0.000001;

    public bool Equals(ClassifiedGridPoint? a, ClassifiedGridPoint? b)
    {
        if (a == null || b == null) return false;

        return Math.Abs(a.X - b.X) < FloatingPointComparisonTolerance &&
               Math.Abs(a.Y - b.Y) < FloatingPointComparisonTolerance &&
               a.Row == b.Row &&
               a.Column == b.Column;
    }

    public int GetHashCode(ClassifiedGridPoint obj)
    {
        return HashCode.Combine(obj.X, obj.Y, obj.Row, obj.Column);
    }
}