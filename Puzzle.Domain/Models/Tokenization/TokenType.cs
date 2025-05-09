namespace Puzzle.Domain.Models.Tokenization;

public enum TokenType
{
    Number,
    Identifier,
    OpenParenthesis, CloseParenthesis,
    BinaryOperator,
    Equals,
    Const,
    EndOfFile,
}