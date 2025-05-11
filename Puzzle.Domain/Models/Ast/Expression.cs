using Puzzle.Domain.Models.Compiler;

namespace Puzzle.Domain.Models.Ast;

public abstract class Expression(NodeType kind, Location start, Location end):Statement(kind, start, end);