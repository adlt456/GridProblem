using GridProblem.Interfaces;

namespace GridProblem.Services;


// higher-level orchestrator. uses grid problem solver and file checker 
public class GridProblemService : IGridProblemService
{
    private readonly IFileParser _parser = new GridPointFileParser();
    private readonly IProblemSolver _solver = new GridProblemSolver();
    
    public string SolveGridProblem(string filePath)
    {
        var result = "";
        
        var points = _parser.ParseFile(filePath);
        var classifiedGridPoints = _solver.GetRowsAndColumns(points.ToList(), out var numPointsPerSquareSide);
        
        AppendRowOrColumnResult(ref result, classifiedGridPoints, numPointsPerSquareSide, true);
        AppendRowOrColumnResult(ref result, classifiedGridPoints, numPointsPerSquareSide, false);
        
        var angle = _solver.CalculateAngle(classifiedGridPoints);
        AppendAngleResult(ref result, angle);
        
        return result;
    }

    private void AppendAngleResult(ref string result, double angle)
    {
        result += $"Alpha={angle:0.0} degrees";
    }

    private static void AppendRowOrColumnResult(ref string result, List<ClassifiedGridPoint> classifiedGridPoints,
        int numPointsPerSquareSide, bool rowOrColumn)
    {
        classifiedGridPoints = classifiedGridPoints.OrderBy(x => x.Row).ToList();
        for (var i = 0; i < numPointsPerSquareSide; ++i)
        {
            result += $"{(rowOrColumn ? "Row" : "Col")} {i}: ";
            var axisIndex = i;
            var rowList = (rowOrColumn
                ? classifiedGridPoints.Where(x => x.Row == axisIndex).OrderBy(x => x.X)
                : classifiedGridPoints.Where(x => x.Column == axisIndex).OrderByDescending(x => x.Y)).ToList();
            result += string.Join(" – ", rowList.Select(p => $"{p.X:0.0},{p.Y:0.0}"));
            result += "\r\n";
        }
    }
}