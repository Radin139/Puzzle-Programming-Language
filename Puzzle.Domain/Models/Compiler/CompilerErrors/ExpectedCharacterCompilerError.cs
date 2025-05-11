namespace Puzzle.Domain.Models.Compiler.CompilerErrors;

public class ExpectedCharacterCompilerError(string expected, Location location):CompilerError($"Expected {expected}", location)
{
    
}