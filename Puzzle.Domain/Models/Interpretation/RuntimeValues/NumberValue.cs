using Puzzle.Domain.Models.Compiler;

namespace Puzzle.Domain.Models.Interpretation.RuntimeValues;

public class NumberValue(int value, Location start, Location end):RuntimeValue(ValueType.Number, value.ToString(), start, end)
{
    public int Value { get; set; } = value;
}