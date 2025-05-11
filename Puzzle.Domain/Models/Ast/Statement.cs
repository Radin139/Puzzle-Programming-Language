using Puzzle.Domain.Models.Compiler;

namespace Puzzle.Domain.Models.Ast;

public abstract class Statement(NodeType kind, Location start, Location end, bool hasBody = false)
{

    public NodeType Kind { get; set; } = kind;
    public Location Start { get; set; } = start;
    public Location End { get; set; } = end;
    public bool HasBody { get; set; } = hasBody;
}