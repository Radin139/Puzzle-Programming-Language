using Puzzle.Data.Implementations;
using Puzzle.Domain.Interfaces;

namespace Puzzle.IoC;

public class UnitOfWork
{
    private GlobalAccess? globalAccess;

    public GlobalAccess GlobalAccess
    {
        get
        {
            if (globalAccess == null)
            {
                globalAccess = new GlobalAccess();
            }
            
            return globalAccess;
        }
    }
    
    private ICompilerHandler? compilerHandler;
    public ICompilerHandler CompilerHandler
    {
        get
        {
            if (compilerHandler == null)
            {
                compilerHandler = new CompilerHandler();
            }
            
            return compilerHandler;
        }
    }
    
    private ILexer? lexer;
    public ILexer Lexer
    {
        get
        {
            if (lexer == null)
            {
                lexer = new Lexer(CompilerHandler, GlobalAccess);
            }
            
            return lexer;
        }
    }
}