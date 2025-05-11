using Puzzle.Domain.Models.Compiler;

namespace Puzzle.Domain.Models.Tokenization;

public class Token(TokenType type, string value, Location location, Location end)
{
    public TokenType Type { get; set; } = type;
    public string Value { get; set; } = value;
    public Location Location { get; set; } = location;
    public Location End { get; set; } = end;
}