// See https://aka.ms/new-console-template for more information

using GridProblem.Services;

namespace GridProblem;

public static class Program
{
    public static void Main(string[] args)
    {
        if (args.Length <= 0) throw new ArgumentException("File path must be provided.");
        
        var solver = new GridProblemService();
        Console.WriteLine(solver.SolveGridProblem(args[0]));
    }
}