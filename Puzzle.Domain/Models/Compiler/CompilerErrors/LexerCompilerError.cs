namespace Puzzle.Domain.Models.Compiler.CompilerErrors;

public class LexerCompilerError(char c, Location location)
    :CompilerError($"Unidentified character found during tokenization: {c}", location)
{
    
}