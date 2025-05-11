using Puzzle.Domain;
using Puzzle.Domain.Interfaces;
using Puzzle.Domain.Models.Ast;
using Puzzle.Domain.Models.Ast.Expressions;
using Puzzle.Domain.Models.Ast.Literals;
using Puzzle.Domain.Models.Ast.Statements;
using Puzzle.Domain.Models.Compiler;
using Puzzle.Domain.Models.Compiler.CompilerErrors;
using Puzzle.Domain.Models.Tokenization;

namespace Puzzle.Data.Implementations;

public class Parser(ILexer lexer, ICompilerHandler handler, GlobalAccess global):IParser
{
    private List<Token> tokens = [];

    #region Helpers

    #region At

    Token at()
    {
        return tokens[0];
    }

    #endregion

    #region NotEndOfFile

    bool notEndOfFile()
    {
        return at().Type != TokenType.EndOfFile;
    }

        #endregion

    #region Next

    Token next()
    {
        return tokens[1];
    }

        #endregion

    #region Eat
    
    Token eat()
    {
        return tokens.Shift();
    }
    
    Token eat(TokenType expected, Func<Location, CompilerError> err)
    {
        if (at().Type != expected)
        {
            handler.Error(err(at().Location));
        }

        return eat();
    }

    #endregion

    #endregion

    #region Produce

    public ProgramStatement Produce(string sourceCode)
    {
        tokens = lexer.Tokenize(sourceCode).ToList();
        List<Statement> statements = new();
        var startloc = at().Location;
        
        while (notEndOfFile())
        {
            Statement statement = parseStatement();

            if (statement.HasBody == false)
            {
                eat(TokenType.Semicolon, location => new SemicolonCompilerError(location));
            }
            
            statements.Add(statement);
        }

        return new(startloc, tokens.Last().Location)
        {
            Body = statements
        };
    }

    #endregion

    #region ParseStatements

    #region ParseStatement

    private Statement parseStatement()
    {
        return parseExpression();
    }

    #endregion

    #endregion

    #region ParseExpressions

    #region ParseExpression

    private Expression parseExpression()
    {
        return parseAdditiveExpression();
    }

    #endregion

    #region ParseAdditiveExpression

    private Expression parseAdditiveExpression()
    {
        Expression left = parseMultiplicativeExpression();

        while (global.AdditiveOperators.Contains(at().Value))
        {
            string @operator = eat().Value;
            Expression right = parseMultiplicativeExpression();
            left = new BinaryOperationExpression(left, right, @operator, left.Start, right.End);
        }
        
        return left;
    }

    #endregion
    
    #region ParseMultiplicativeExpression

    private Expression parseMultiplicativeExpression()
    {
        Expression left = parsePrimaryExpression();

        while (global.MultiplicativeOperators.Contains(at().Value))
        {
            string @operator = eat().Value;
            Expression right = parsePrimaryExpression();
            left = new BinaryOperationExpression(left, right, @operator, left.Start, right.End);
        }
        
        return left;
    }
    
    #endregion

    #region ParsePrimaryExpression

    private Expression parsePrimaryExpression()
    {
        var token = eat();
        switch (token.Type)
        {
            case TokenType.Number:
                return new NumericLiteralExpression(Convert.ToInt32(token.Value), token.Location, token.End);
            case TokenType.Identifier:
                return new IdentifierExpression(token.Value, token.Location, token.End);
            default:
                handler.Error(new ParserCompilerError(token.Value, token.Location));
                return null;
        }
    }

    #endregion

    #endregion
}