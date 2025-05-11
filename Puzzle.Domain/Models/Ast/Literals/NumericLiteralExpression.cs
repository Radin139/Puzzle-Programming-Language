using Puzzle.Domain.Models.Compiler;

namespace Puzzle.Domain.Models.Ast.Literals;

public class NumericLiteralExpression(int value, Location start, Location end) : Expression(NodeType.NumericLiteral, start, end)
{
    public int Value { get; set; } = value;
}