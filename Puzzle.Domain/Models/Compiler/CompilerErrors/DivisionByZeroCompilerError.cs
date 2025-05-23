namespace Puzzle.Domain.Models.Compiler.CompilerErrors;

public class DivisionByZeroCompilerError(Location location):CompilerError("Cannot divide by zero", location)
{
    
}