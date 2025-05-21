using System.Text.Json;
using GridProblem.Interfaces;
using GridProblem.Models;
using GridProblem.Services;

namespace GridProblemTest;

[TestFixture]
public class GridPointFileParserTests
{
    private IFileParser _parser;        
    private const string DataSampleInputPath = @"Data\SampleInput1.txt";
    
    [SetUp]
    public void Setup()
    {
        _parser = new GridPointFileParser();
    }


    [Test]
    public void SampleParseTest()
    {
        var expected = new List<GridPoint>()
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

        Assert.That(JsonSerializer.Serialize(_parser.ParseFile(DataSampleInputPath)), Is.EqualTo(JsonSerializer.Serialize(expected)));
    }
}