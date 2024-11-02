namespace Linq01.Extensions02;

public static class Extensions02
{
    public static Dictionary<TKey, IEnumerable<T>> Partition<T, TKey>(this IEnumerable<T> items, Func<T, TKey> keySelector)
    where TKey : notnull
    {
        return items.GroupBy(keySelector).ToDictionary(group => group.Key, group => group.AsEnumerable());
    }

    public static IDictionary<TKey, IEnumerable<T>> OrderAllGroups<T, TKey, TProperty>(
        this IDictionary<TKey, IEnumerable<T>> groupedItems,
        Func<T, TProperty> propertySelector)
    {
        foreach (TKey key in groupedItems.Keys)
            groupedItems[key] = groupedItems[key].ThenOrderBy(propertySelector);

        return groupedItems;
    }

    public static IDictionary<TKey, IEnumerable<T>> OrderAllGroupsDescending<T, TKey, TProperty>(
        this IDictionary<TKey, IEnumerable<T>> groupedItems,
        Func<T, TProperty> propertySelector)
    {
        foreach (TKey key in groupedItems.Keys)
            groupedItems[key] = groupedItems[key].ThenOrderByDescending(propertySelector);

        return groupedItems;
    }

    public static IDictionary<TKey, IEnumerable<T>> OrderGroup<T, TKey, TProperty>(
        this IDictionary<TKey, IEnumerable<T>> groupedItems,
        TKey groupKey,
        Func<T, TProperty> propertySelector)
    {
        if (groupedItems.TryGetValue(groupKey, out IEnumerable<T>? groupValue))
            groupedItems[groupKey] = groupValue.ThenOrderBy(propertySelector);

        return groupedItems;
    }

    public static IDictionary<TKey, IEnumerable<T>> OrderGroupDescending<T, TKey, TProperty>(
        this IDictionary<TKey, IEnumerable<T>> groupedItems,
        TKey groupKey,
        Func<T, TProperty> propertySelector)
    {
        if (groupedItems.TryGetValue(groupKey, out IEnumerable<T>? groupValue))
            groupedItems[groupKey] = groupValue.ThenOrderByDescending(propertySelector);

        return groupedItems;
    }

    public static IDictionary<TKey, IEnumerable<T>> OrderGroupWhen<T, TKey, TProperty>(
        this IDictionary<TKey, IEnumerable<T>> groupedItems,
        Func<bool> predicate,
        TKey groupKey,
        Func<T, TProperty> propertySelector)
    {
        if (predicate())
            groupedItems.OrderGroup(groupKey, propertySelector);

        return groupedItems;
    }

    public static IDictionary<TKey, IEnumerable<T>> OrderGroupWhenDescending<T, TKey, TProperty>(
        this IDictionary<TKey, IEnumerable<T>> groupedItems,
        Func<bool> predicate,
        TKey groupKey,
        Func<T, TProperty> propertySelector)
    {
        if (predicate())
            groupedItems.OrderGroupDescending(groupKey, propertySelector);

        return groupedItems;
    }

    public static IEnumerable<T> ConcatGroups<T, TKey>(this IDictionary<TKey, IEnumerable<T>> groupedItems)
    {
        return groupedItems.SelectMany(group => group.Value);
    }

    /// <summary>
    /// If the group is already ordered, then it calls ThenBy. Otherwise, it calls OrderBy.
    /// </summary>
    private static IOrderedEnumerable<T> ThenOrderBy<T, TProperty>(this IEnumerable<T> groupValue, Func<T, TProperty> propertySelector)
    {
        return groupValue switch
        {
            IOrderedEnumerable<T> orderedGroup => orderedGroup.ThenBy(propertySelector),
            IEnumerable<T> unorderedGroup => unorderedGroup.OrderBy(propertySelector),
        };
    }

    /// <summary>
    /// If the group is already ordered, then it calls ThenByDescending. Otherwise, it calls OrderByDescending.
    /// </summary>
    private static IOrderedEnumerable<T> ThenOrderByDescending<T, TProperty>(this IEnumerable<T> groupValue, Func<T, TProperty> propertySelector)
    {
        return groupValue switch
        {
            IOrderedEnumerable<T> orderedGroup => orderedGroup.ThenByDescending(propertySelector),
            IEnumerable<T> unorderedGroup => unorderedGroup.OrderByDescending(propertySelector),
        };
    }
}