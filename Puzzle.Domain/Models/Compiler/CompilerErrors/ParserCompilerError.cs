using Puzzle.Domain.Models.Tokenization;

namespace Puzzle.Domain.Models.Compiler.CompilerErrors;

public class ParserCompilerError(string token, Location location)
    :CompilerError($"Unidentified token found during parsing: {token}", location)
{
    
}