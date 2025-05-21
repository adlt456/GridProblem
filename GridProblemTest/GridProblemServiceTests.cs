using GridProblem.Interfaces;
using GridProblem.Services;

namespace GridProblemTest;

[TestFixture]
public class GridProblemServiceTests
{
    IGridProblemService _gridProblemService;
    private const string DataSampleInputPath = @"Data\SampleInput1.txt";


    [SetUp]
    public void SetUp()
    {
        _gridProblemService = new GridProblemService();
    }

    [Test]
    public void UnRotatedSquareTest()
    {
        var result = _gridProblemService.SolveGridProblem(DataSampleInputPath);
        
        const string expectedOutput = "Row 0: 10.0,14.0 – 12.0,14.0 – 14.0,14.0\r\n" +
                                      "Row 1: 10.0,12.0 – 12.0,12.0 – 14.0,12.0\r\n" +
                                      "Row 2: 10.0,10.0 – 12.0,10.0 – 14.0,10.0\r\n" +
                                      "Col 0: 10.0,14.0 – 10.0,12.0 – 10.0,10.0\r\n" +
                                      "Col 1: 12.0,14.0 – 12.0,12.0 – 12.0,10.0\r\n" +
                                      "Col 2: 14.0,14.0 – 14.0,12.0 – 14.0,10.0\r\n" +
                                      "Alpha=0.0 degrees";
        
        Assert.That(result, Is.EqualTo(expectedOutput));
    }
}