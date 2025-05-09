using Puzzle.Domain.Models.Tokenization;

namespace Puzzle.Domain.Interfaces;

public interface ILexer
{
    IEnumerable<Token> Tokenize(string sourceCode);
}