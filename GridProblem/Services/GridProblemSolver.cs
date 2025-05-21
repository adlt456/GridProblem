using GridProblem.Interfaces;

namespace GridProblem.Services;

// solves and returns output from a set of points
public class GridProblemSolver : IProblemSolver
{
    // works under the assumption that the lowest point of row n is greater than the highest point of row n + 1. not completely rotation-invariant.
    public List<ClassifiedGridPoint> GetRowsAndColumns(List<GridPoint> points, out int numPointsPerSquareSide)
    { 
        var result = points
            .Select(p => new ClassifiedGridPoint
            {
                X = p.X,
                Y = p.Y,
                Row = -1,
                Column = -1
            })
            .ToList();
        
        numPointsPerSquareSide = (int) Math.Sqrt(points.Count); // assuming points provided are perfect square number

        PopulateRowOrColumnNum(result, numPointsPerSquareSide, true);
        PopulateRowOrColumnNum(result, numPointsPerSquareSide, false);
        return result;
    }
    
    /// <returns>Angle in degrees</returns>
    public double CalculateAngle(List<ClassifiedGridPoint> points)
    {
        var rowPoints = points.Where(x => x.Row == 0).OrderBy(x => x.X).ToList(); //any row works. using the one common to all valid inputs.
        var point1 = rowPoints[0];
        var point2 = rowPoints[^1];
        
        var resultRadians = Math.Atan2( point2.Y - point1.Y, point2.X - point1.X);
        return resultRadians * (180 / Math.PI);
    }
    
    /// <param name="numPointsPerSquareSide"></param>
    /// <param name="rowOrColumn">set to true for row classification, else column</param>
    /// <param name="pointsToClassify"></param>
    private void PopulateRowOrColumnNum(List<ClassifiedGridPoint> pointsToClassify, int numPointsPerSquareSide, bool rowOrColumn)
    {
        
        pointsToClassify = rowOrColumn ?  pointsToClassify.OrderByDescending(x => x.Y).ToList() : pointsToClassify.OrderBy(x => x.X).ToList();
        
        for (var i = 0; i < pointsToClassify.Count; ++i)
        {
            var classificationNum = i / numPointsPerSquareSide;
            
            if (rowOrColumn)
                pointsToClassify[i].Row = classificationNum;
            else
                pointsToClassify[i].Column = classificationNum;
        }

    }
    
    
}