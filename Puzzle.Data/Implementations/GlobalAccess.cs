using Puzzle.Domain.Models.Tokenization;

namespace Puzzle.Data.Implementations;

public class GlobalAccess
{
    public GlobalAccess()
    {
        AdditiveOperators = ["+", "-"];
        MultiplicativeOperators = ["*", "/", "%"];
        BinaryOperators = AdditiveOperators.Concat(MultiplicativeOperators).ToList();
        Keywords = new()
        {
            { "const", TokenType.Const },
        };
        Skippables = [' ', '\n', '\r', '\t'];
    }

    public List<string> AdditiveOperators { get; }
    public List<string> MultiplicativeOperators { get; }
    public List<string> BinaryOperators { get; }
    public Dictionary<string, TokenType> Keywords { get; }
    public List<char> Skippables { get; }
}