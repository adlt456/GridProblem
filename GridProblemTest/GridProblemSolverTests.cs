using GridProblem.Comparers;
using GridProblem.Interfaces;
using GridProblem.Models;
using GridProblem.Services;

namespace GridProblemTest;

[TestFixture]
public class GridProblemSolverTests
{
    private IProblemSolver _solver;
    
    [SetUp]
    public void Setup()
    {
        _solver = new GridProblemSolver();
    }
    
    [Test]
    public void SampleInput1Test()
    {
        var input = new List<GridPoint>()
        {
            new() { X = 14.0, Y = 10.0 },
            new() { X = 10.0, Y = 10.0 },
            new() { X = 12.0, Y = 10.0 },
            
            new() { X = 10.0, Y = 12.0 },
            new() { X = 10.0, Y = 14.0 },
            new() { X = 12.0, Y = 12.0 },
            
            new() { X = 14.0, Y = 12.0 },
            new() { X = 14.0, Y = 14.0 },
            new() { X = 12.0, Y = 14.0 },
        };


        var result = _solver.GetRowsAndColumns(input, out _);
        
        
        var expected = new List<ClassifiedGridPoint>()
        {
            new() { X = 10.0, Y = 14.0, Row = 0, Column = 0 },
            new() { X = 12.0, Y = 14.0, Row = 0, Column = 1 },
            new() { X = 14.0, Y = 14.0, Row = 0, Column = 2 },
    
            new() { X = 10.0, Y = 12.0, Row = 1, Column = 0 },
            new() { X = 12.0, Y = 12.0, Row = 1, Column = 1 },
            new() { X = 14.0, Y = 12.0, Row = 1, Column = 2 },
    
            new() { X = 10.0, Y = 10.0, Row = 2, Column = 0 },
            new() { X = 12.0, Y = 10.0, Row = 2, Column = 1 },
            new() { X = 14.0, Y = 10.0, Row = 2, Column = 2 },
        };

        Assert.That(result.OrderBy(x => x.X).ThenBy(x => x.Y),
            Is.EqualTo(expected.OrderBy(x => x.X).ThenBy(x => x.Y)).Using(new ClassifiedGridPointComparer()));
    }
    
    [Test]
    public void SampleInput2Test()
    {
        var input = new List<GridPoint>()
        {
            new() { X = 10.0, Y = 10.0 },
            new() { X = 12.0, Y = 10.1 },
            new() { X = 14.0, Y = 10.3 },
            new() { X = 9.9, Y = 12.0 },
            new () { X = 11.8, Y = 12.1 },
            new () { X = 13.8, Y = 12.3 },
            new () { X = 9.7, Y = 14.0 },
            new () { X = 11.7, Y = 14.1 },
            new () { X = 13.7, Y = 14.3 }
        };

        var result = _solver.GetRowsAndColumns(input, out _);
        
        
        var expected = new List<ClassifiedGridPoint>()
        {
            new() { X = 10.0, Y = 10.0, Row = 2, Column = 0 },
            new() { X = 12.0, Y = 10.1, Row = 2, Column = 1 },
            new() { X = 14.0, Y = 10.3, Row = 2, Column = 2 },

            new() { X = 9.9, Y = 12.0, Row = 1, Column = 0 },
            new() { X = 11.8, Y = 12.1, Row = 1, Column = 1 },
            new() { X = 13.8, Y = 12.3, Row = 1, Column = 2 },

            new() { X = 9.7, Y = 14.0, Row = 0, Column = 0 },
            new() { X = 11.7, Y = 14.1, Row = 0, Column = 1 },
            new() { X = 13.7, Y = 14.3, Row = 0, Column = 2 },
        };


        Assert.That(result.OrderBy(x => x.X).ThenBy(x => x.Y),
            Is.EqualTo(expected.OrderBy(x => x.X).ThenBy(x => x.Y)).Using(new ClassifiedGridPointComparer()));
    }
}