namespace MauMau.GameLogic.Extensions;

internal static class CollectionExtensions
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

    public static List<T> RemoveAndGetRange<T>(
        this List<T> list,
        int index,
        int count)
    {
        List<T> range = list.GetRange(index, count);
        list.RemoveRange(index, count);
        return range;
    }
}