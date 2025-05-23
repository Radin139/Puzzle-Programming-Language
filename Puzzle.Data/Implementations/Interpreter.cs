using Puzzle.Domain.Interfaces;
using Puzzle.Domain.Models.Ast;
using Puzzle.Domain.Models.Ast.Expressions;
using Puzzle.Domain.Models.Ast.Literals;
using Puzzle.Domain.Models.Ast.Statements;
using Puzzle.Domain.Models.Compiler;
using Puzzle.Domain.Models.Compiler.CompilerErrors;
using Puzzle.Domain.Models.Interpretation;
using Puzzle.Domain.Models.Interpretation.RuntimeValues;
using Environment = Puzzle.Domain.Models.Interpretation.Environment;
using ValueType = Puzzle.Domain.Models.Interpretation.ValueType;

namespace Puzzle.Data.Implementations;

public class Interpreter(ICompilerHandler handler):IInterpreter
{
    #region Evaluate

    public RuntimeValue Evaluate(Statement node, Environment env)
    {
        switch (node.Kind)
        {
            case NodeType.NumericLiteral:
                return new NumberValue((node as NumericLiteralExpression).Value, node.Start, node.End);
            case NodeType.Program:
                return evaluateProgramStatement(node as ProgramStatement, env);
            case NodeType.BinaryOperation:
                return evaluateBinaryOperation(node as BinaryOperationExpression, env);
            case NodeType.Identifier:
                return evaluateIdentifierExpression(node as IdentifierExpression, env);
            default:
                handler.Error(new InterpreterCompilerError(node.Kind, node.Start));
                return null;
        }
    }

    #endregion

    #region EvaluateIdentifierExpression

    private RuntimeValue evaluateIdentifierExpression(IdentifierExpression identifier, Environment env)
    {
        return env.Lookup(identifier.Symbol, identifier.Start).Value;
    }

    #endregion

    #region EvaluateProgramStatement

    private RuntimeValue evaluateProgramStatement(ProgramStatement program, Environment env)
    {
        RuntimeValue lastEvaluated = new EmptyValue(program.Start, program.End);

        foreach (var statement in program.Body)
        {
            lastEvaluated = Evaluate(statement, env);
        }
        
        return lastEvaluated;
    }

    #endregion

    #region BinaryOperation

    #region EvaluateBinaryOperation

    private RuntimeValue evaluateBinaryOperation(BinaryOperationExpression binop, Environment env)
    {
        RuntimeValue left = Evaluate(binop.Left, env);
        RuntimeValue right = Evaluate(binop.Right, env);

        if (left.Type == ValueType.Number && right.Type == ValueType.Number)
        {
            return evaluateNumericBinaryOperation(left as NumberValue, right as NumberValue, binop.Operator, env);
        }

        return new EmptyValue(binop.Start, binop.End);
    }

    #endregion
    
    #region EvaluateNumericBinaryOperation

    private RuntimeValue evaluateNumericBinaryOperation(NumberValue left, NumberValue right, string @operator, Environment env)
    {
        int result = 0;
        
        switch (@operator)
        {
            case "+":
                result = left.Value + right.Value;
                break;
            case "-":
                result = left.Value - right.Value;
                break;
            case "*":
                result = left.Value * right.Value;
                break;
            case "/":
                if (right.Value == 0)
                {
                    handler.Error(new DivisionByZeroCompilerError(right.Start));
                }
                
                result = left.Value / right.Value;
                break;
            case "%":
                if (right.Value == 0)
                {
                    handler.Error(new DivisionByZeroCompilerError(right.Start));
                }
                
                result = left.Value % right.Value;
                break;
        }
        
        return new NumberValue(result, left.Start, right.End);
    }
    
    #endregion

    #endregion
}