using Puzzle.Domain.Models.Compiler;

namespace Puzzle.Domain.Models.Ast.Expressions;

public class IdentifierExpression(string symbol, Location start, Location end):Expression(NodeType.Identifier, start, end)
{
    public string Symbol { get; set; } = symbol;
}