using System.Runtime.Remoting;
using Puzzle.Domain.Models.Tokenization;

namespace Puzzle.Domain;

public static class Extensions
{
    public static T Shift<T>(this List<T> list)
    {
        T result = list.First();
        list.Remove(result);
        return result;
    }
}