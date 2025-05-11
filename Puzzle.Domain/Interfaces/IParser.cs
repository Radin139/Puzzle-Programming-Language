using Puzzle.Domain.Models.Ast.Statements;

namespace Puzzle.Domain.Interfaces;

public interface IParser
{
    ProgramStatement Produce(string sourceCode);
}