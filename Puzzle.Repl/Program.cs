// See https://aka.ms/new-console-template for more information

using Puzzle.IoC;

UnitOfWork context = new();

var tokens = context.Lexer.Tokenize("const ^ a = 3\na = (45 + 3 * 2)").ToList();

foreach (var token in tokens)
{
    Console.WriteLine($"{token.Type}: {token.Value} At {token.Location}");
}