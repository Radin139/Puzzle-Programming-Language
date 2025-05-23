using Puzzle.Domain;
using Puzzle.Domain.Interfaces;
using Puzzle.Domain.Models.Compiler;
using Puzzle.Domain.Models.Compiler.CompilerErrors;
using Puzzle.Domain.Models.Tokenization;
namespace Puzzle.Data.Implementations;

public class Lexer(ICompilerHandler handler, GlobalAccess global):ILexer
{
    
    public IEnumerable<Token> Tokenize(string sourceCode)
    {
        List<Token> tokens = new List<Token>();
        List<char> src = sourceCode.ToCharArray().ToList();
        int line = 1;
        int column = 1;
        var startloc = new Location(line, column);
        
        while (src.Count > 0)
        {
            switch (src[0])
            {
                case '=':
                    startloc = new Location(line, column);
                    column++;
                    tokens.Add(new Token(TokenType.Equals, src.Shift().ToString(), startloc, new Location(line, column)));
                    break;
                case ';':
                    startloc = new Location(line, column);
                    column++;
                    tokens.Add(new Token(TokenType.Semicolon, src.Shift().ToString(), startloc, new Location(line, column)));
                    break;
                case '(':
                    startloc = new Location(line, column);
                    column++;
                    tokens.Add(new Token(TokenType.OpenParenthesis, src.Shift().ToString(), startloc, new Location(line, column)));
                    break;
                case ')':
                    startloc = new Location(line, column);
                    column++;
                    tokens.Add(new Token(TokenType.CloseParenthesis, src.Shift().ToString(), startloc, new Location(line, column)));
                    break;
                default:
                    if (global.BinaryOperators.Contains(src[0].ToString()))
                    {
                        startloc = new Location(line, column);
                        column++;
                        tokens.Add(new Token(TokenType.BinaryOperator, src.Shift().ToString(), startloc, new Location(line, column)));
                    }
                    else if (char.IsNumber(src[0]))
                    {
                        startloc = new Location(line, column);
                        string number = "";

                        while (src.Count > 0 && char.IsNumber(src[0]))
                        {
                            column++;
                            number += src.Shift();
                        }
                        
                        tokens.Add(new Token(TokenType.Number, number, startloc, new Location(line, column)));
                    }
                    else if (char.IsLetter(src[0]))
                    {
                        startloc = new Location(line, column);
                        string ident = "";

                        while (src.Count > 0 && (char.IsLetterOrDigit(src[0]) || src[0] == '_'))
                        {
                            ident += src.Shift();
                            column++;
                        }

                        tokens.Add(global.Keywords.TryGetValue(ident, out var keyword)
                            ? new Token(keyword, ident, startloc, new Location(line, column))
                            : new Token(TokenType.Identifier, ident, startloc, new Location(line, column)));
                    }
                    else if(global.Skippables.Contains(src[0]))
                    {
                        char skip = src.Shift();
                        if (skip == '\r')
                        {
                            if (src[0] == '\n')
                            {
                                src.Shift();
                            }
                            
                            line++;
                        }
                        else if (skip == '\n')
                        {
                            line++;
                        }
                        else
                        {
                            column++;
                        }
                    }
                    else
                    {
                        handler.Error(new LexerCompilerError(src[0], new Location(line, column)));
                    }
                    
                    break;
            }
        }
        
        tokens.Add(new Token(TokenType.EndOfFile, "", new Location(line, column), new Location(line, column)));
        return tokens;
    }
}