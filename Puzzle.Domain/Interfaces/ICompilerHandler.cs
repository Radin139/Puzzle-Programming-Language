using Puzzle.Domain.Models.Compiler;

namespace Puzzle.Domain.Interfaces;

public interface ICompilerHandler
{
    void Error(CompilerError error);
}