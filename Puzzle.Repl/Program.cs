// See https://aka.ms/new-console-template for more information

using Puzzle.Domain;
using Puzzle.IoC;

UnitOfWork context = new();

var program = context.Parser.Produce("1299 + 1;");

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\nEnd Puzzle Script");
Console.ResetColor();