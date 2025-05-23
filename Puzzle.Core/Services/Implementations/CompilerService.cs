using Puzzle.Core.Services.Interfaces;
using Puzzle.Domain.Interfaces;
using Puzzle.Domain.Models.Ast.Statements;
using Puzzle.Domain.Models.Compiler;
using Puzzle.Domain.Models.Interpretation;
using Puzzle.Domain.Models.Interpretation.RuntimeValues;
using Environment = Puzzle.Domain.Models.Interpretation.Environment;
using ValueType = Puzzle.Domain.Models.Interpretation.ValueType;

namespace Puzzle.Core.Services.Implementations;

public class CompilerService(IParser parser, IInterpreter interpreter, ICompilerHandler handler):ICompilerService
{
    public string Compiler(string code)
    {
        var compilerPointer = new CompilerLocation();
        Environment env = new Environment(handler);
        env.Declare("empty", ValueType.Empty, new EmptyValue(compilerPointer, compilerPointer), true, compilerPointer);
        env.Declare("true", ValueType.State, new StateValue(true, compilerPointer, compilerPointer), true, compilerPointer);
        env.Declare("false", ValueType.State, new StateValue(false, compilerPointer, compilerPointer), true, compilerPointer);
        
        ProgramStatement program = parser.Produce(code);
        RuntimeValue runtimeValue = interpreter.Evaluate(program, env);
        return runtimeValue.Inner;
    }
}