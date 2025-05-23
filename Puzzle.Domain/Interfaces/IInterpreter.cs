using Puzzle.Domain.Models.Ast;
using Puzzle.Domain.Models.Interpretation;
using Environment = Puzzle.Domain.Models.Interpretation.Environment;

namespace Puzzle.Domain.Interfaces;

public interface IInterpreter
{
    RuntimeValue Evaluate(Statement node, Environment env);
}