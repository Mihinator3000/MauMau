namespace MauMau.GameLogic.Extensions;

internal static class EnumerableExtensions
{
    public static IEnumerable<T> AppendIf<T>(
        this IEnumerable<T> enumerable,
        T element,
        Func<T, bool> predicate)
    {
        return predicate(element)
            ? enumerable.Append(element)
            : enumerable;
    }
}