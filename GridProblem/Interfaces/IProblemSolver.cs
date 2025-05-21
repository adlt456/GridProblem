using GridProblem.Services;

namespace GridProblem.Interfaces;

public interface IProblemSolver
{
    List<ClassifiedGridPoint> GetRowsAndColumns(List<GridPoint> points, out int numPointsPerSquareSide);
    double CalculateAngle(List<ClassifiedGridPoint> points);

}