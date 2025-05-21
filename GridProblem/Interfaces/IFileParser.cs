using GridProblem.Services;

namespace GridProblem.Interfaces;

public interface IFileParser
{
    IList<GridPoint> ParseFile(string filePath);

    IList<GridPoint> ParseContents(string fileContents);
}