using Puzzle.Domain.Models.Compiler;

namespace Puzzle.Domain.Models.Interpretation.RuntimeValues;

public class EmptyValue(Location start, Location end):RuntimeValue(ValueType.Empty, "empty", start, end);