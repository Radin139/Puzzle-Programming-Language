using Puzzle.Domain.Interfaces;
using Puzzle.Domain.Models.Compiler;

namespace Puzzle.Data.Implementations;

public class CompilerHandler:ICompilerHandler
{
    public void Error(CompilerError error)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(error.Message);
        Console.ResetColor();
        System.Environment.Exit(1);
    }
}