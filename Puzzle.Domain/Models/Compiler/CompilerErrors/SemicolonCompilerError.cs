namespace Puzzle.Domain.Models.Compiler.CompilerErrors;

public class SemicolonCompilerError(Location location):ExpectedCharacterCompilerError(";", location)
{
    
}