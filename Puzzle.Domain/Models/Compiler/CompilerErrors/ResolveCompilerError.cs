namespace Puzzle.Domain.Models.Compiler.CompilerErrors;

public class ResolveCompilerError(string varname, Location location):CompilerError($"Cannot resolve variable '{varname}'", location);