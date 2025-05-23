namespace Puzzle.Domain.Models.Compiler.CompilerErrors;

public class AssignmentToConstantCompilerError(string varname, Location location):CompilerError($"Cannot assign to constant '{varname}'", location);