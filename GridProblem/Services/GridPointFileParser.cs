using GridProblem.Interfaces;
using GridProblem.Models;

namespace GridProblem.Services;

public class GridPointFileParser : IFileParser
{
    // assuming 'happy path' contents
    public IList<GridPoint> ParseFile(string filePath)
    {
        var fullPath = Path.GetFullPath(filePath);
        if (!Path.Exists(fullPath)) throw new FileNotFoundException();
            
        var fileContents = File.ReadAllText(fullPath);

        return ParseContents(fileContents);
    }

    public IList<GridPoint> ParseContents(string fileContents)
    {
        var result = new List<GridPoint>();
        var lines = fileContents.Trim().Split("\r\n", StringSplitOptions.TrimEntries);

        foreach (var line in lines)
        {
            var coordinates = line.Split(",", StringSplitOptions.TrimEntries);
            if (coordinates.Length == 2)
                result.Add(new GridPoint() { X = double.Parse(coordinates[0]), Y = double.Parse(coordinates[1]) });
            else
                Console.WriteLine("Error: Unexpected number of coordinate values.");
            
        }

        return result;
    }
}