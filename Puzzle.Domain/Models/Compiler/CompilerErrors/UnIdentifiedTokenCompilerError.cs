namespace Puzzle.Domain.Models.Compiler.CompilerErrors;

public class UnIdentifiedTokenCompilerError(char token, Location location)
    :CompilerError($"Unidentified token found during tokenization: {token}", location)
{
    
}