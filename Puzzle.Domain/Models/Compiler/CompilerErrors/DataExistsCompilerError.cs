namespace Puzzle.Domain.Models.Compiler.CompilerErrors;

public class DataExistsCompilerError(string identifier, Location location):CompilerError($"Variable '{identifier}' exists", location);