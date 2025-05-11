namespace Puzzle.Domain.Models.Ast;

public enum NodeType
{
    // Statements
    Program,
    
    // Expressions
    Identifier,
    BinaryOperation,
    
    // Literals
    NumericLiteral,
}