using Puzzle.Domain.Models.Compiler;

namespace Puzzle.Domain.Models.Ast.Statements;

public class ProgramStatement(Location start, Location end):Statement(NodeType.Program, start, end, true)
{
    public List<Statement> Body { get; set; } = [];
}