namespace Puzzle.Domain.Models.Interpretation;
public class Container(ValueType dataType, RuntimeValue value, bool isConstant)
{
    public bool IsConstant { get; set; } = isConstant;
    public ValueType DataType { get; set; } = dataType;
    public RuntimeValue Value { get; set; } = value;
}