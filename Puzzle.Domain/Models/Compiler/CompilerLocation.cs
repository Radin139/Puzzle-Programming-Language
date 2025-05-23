namespace Puzzle.Domain.Models.Compiler;

public class CompilerLocation():Location(1, 1)
{
    public override string ToString()
    {
        return "Compiler";
    }
}