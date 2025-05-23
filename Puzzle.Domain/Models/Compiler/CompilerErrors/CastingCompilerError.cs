using ValueType = Puzzle.Domain.Models.Interpretation.ValueType;

namespace Puzzle.Domain.Models.Compiler.CompilerErrors;

public class CastingCompilerError(ValueType baseType, ValueType valueType, Location location):CompilerError($"Cannot cast {valueType} to {baseType}", location);