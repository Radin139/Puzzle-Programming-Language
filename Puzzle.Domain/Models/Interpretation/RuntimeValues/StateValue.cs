using Puzzle.Domain.Models.Compiler;

namespace Puzzle.Domain.Models.Interpretation.RuntimeValues;

public class StateValue(bool value, Location start, Location end):RuntimeValue(ValueType.State, value.ToString(), start, end)
{
    public bool Value { get; set; } = value;
}