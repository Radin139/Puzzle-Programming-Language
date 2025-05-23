// See https://aka.ms/new-console-template for more information

using Puzzle.Domain;
using Puzzle.IoC;
using Environment = Puzzle.Domain.Models.Interpretation.Environment;

UnitOfWork context = new();

Console.WriteLine(context.CompilerService.Compiler(File.ReadAllText("E:\\Projects\\Puzzle\\Puzzle Programming Language\\Puzzle.Repl\\main.puzzle")));

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\nEnd Puzzle Script");
Console.ResetColor();