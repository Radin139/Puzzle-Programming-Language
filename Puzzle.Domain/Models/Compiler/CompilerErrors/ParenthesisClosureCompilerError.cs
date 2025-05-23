namespace Puzzle.Domain.Models.Compiler.CompilerErrors;

public class ParenthesisClosureCompilerError(Location location):ExpectedCharacterCompilerError(")", location)
{
    
}