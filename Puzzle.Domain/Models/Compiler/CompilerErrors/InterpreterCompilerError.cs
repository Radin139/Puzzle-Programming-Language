using Puzzle.Domain.Models.Ast;

namespace Puzzle.Domain.Models.Compiler.CompilerErrors;

public class InterpreterCompilerError(NodeType nodeType, Location location):CompilerError($"{nodeType} node cannot be interpreted", location)
{
    
}