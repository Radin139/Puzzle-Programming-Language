using Puzzle.Domain.Models.Compiler;

namespace Puzzle.Domain.Models.Ast.Expressions;

public class BinaryOperationExpression(Expression left, Expression right, string @operator, Location start, Location end):Expression(NodeType.BinaryOperation, start, end)
{
    public Expression Left { get; set; } = left;
    public Expression Right { get; set; } = right;
    public string Operator { get; set; } = @operator;
}