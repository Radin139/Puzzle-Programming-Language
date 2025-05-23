using Puzzle.Domain.Models.Compiler;

namespace Puzzle.Domain.Models.Interpretation;

public abstract class RuntimeValue(ValueType type, string inner, Location start, Location end)
{
    public ValueType Type { get; set; } = type;
    public string Inner { get; set; } = inner;
    public Location Start { get; set; } = start;
    public Location End { get; set; } = end;
}