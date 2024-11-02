namespace Linq01.Extensions01;

public static class Extensions01
{
    public static Dictionary<bool, IEnumerable<T>> Partition<T>(this IEnumerable<T> items, Func<T, bool> predicate)
    {
        return items.GroupBy(predicate).ToDictionary(group => group.Key, group => group.AsEnumerable());
    }

    public static IDictionary<TKey, IEnumerable<T>> OrderAllGroups<TKey, T>(
        this IDictionary<TKey, IEnumerable<T>> groupedItems,
        Func<IEnumerable<T>, IOrderedEnumerable<T>> orderFunction)
    {
        foreach (TKey key in groupedItems.Keys)
            groupedItems[key] = orderFunction(groupedItems[key]); // Bad approach!

        // The problem with this approach is that it replaces the order of the group
        // with the order given by the last call to this method.
        // This needs to know whether the group was already ordered or not,
        // trying casting it to IOrderedEnumerable<T>, and call ThenBy if it was.

        return groupedItems;
    }

    public static IDictionary<TKey, IEnumerable<T>> OrderGroup<TKey, T>(
        this IDictionary<TKey, IEnumerable<T>> groupedItems,
        TKey groupKey,
        Func<IEnumerable<T>, IOrderedEnumerable<T>> orderFunction)
    {
        if (groupedItems.TryGetValue(groupKey, out IEnumerable<T>? groupValue))
            groupedItems[groupKey] = orderFunction(groupValue); // Bad approach!

        // The problem with this approach is that it replaces the order of the group
        // with the order given by the last call to this method.
        // This needs to know whether the group was already ordered or not,
        // trying casting it to IOrderedEnumerable<T>, and call ThenBy if it was.

        return groupedItems;
    }

    public static IDictionary<TKey, IEnumerable<T>> OrderGroupWhen<TKey, T>(
        this IDictionary<TKey, IEnumerable<T>> groupedItems,
        Func<bool> predicate,
        TKey groupKey,
        Func<IEnumerable<T>, IOrderedEnumerable<T>> orderFunction)
    {
        if (predicate())
            groupedItems.OrderGroup(groupKey, orderFunction);

        return groupedItems;
    }

    public static IEnumerable<T> ConcatGroups<TKey, T>(this IDictionary<TKey, IEnumerable<T>> groupedItems)
    {
        return groupedItems.SelectMany(group => group.Value);
    }
}