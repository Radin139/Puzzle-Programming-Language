namespace Puzzle.Domain.Models.Compiler;

public class CompilerError(string message, Location location)
{
    public string Message { get; set; } = message + $" At {location}";
    public Location Location { get; set; } = location;
}