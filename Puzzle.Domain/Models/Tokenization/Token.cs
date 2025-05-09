using Puzzle.Domain.Models.Compiler;

namespace Puzzle.Domain.Models.Tokenization;

public class Token(TokenType type, string value, Location location)
{
    public TokenType Type { get; set; } = type;
    public string Value { get; set; } = value;
    public Location Location { get; set; } = location;
}