using Puzzle.Core.Services.Implementations;
using Puzzle.Core.Services.Interfaces;
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
    
    private IParser? parser;
    public IParser Parser
    {
        get
        {
            if (parser == null)
            {
                parser = new Parser(Lexer, CompilerHandler, GlobalAccess);
            }
            
            return parser;
        }
    }
    
    private IInterpreter? interpreter;
    public IInterpreter Interpreter
    {
        get
        {
            if (interpreter == null)
            {
                interpreter = new Interpreter(CompilerHandler);
            }
            
            return interpreter;
        }
    }
    
    private ICompilerService? compilerService;
    public ICompilerService CompilerService
    {
        get
        {
            if (compilerService == null)
            {
                compilerService = new CompilerService(Parser, Interpreter, CompilerHandler);
            }
            
            return compilerService;
        }
    }
}