# LINQ Exercise 01

Create extension methods to sort a list by some item property.

Create an extension method to partition a list by some item criteria.

```cs
List<Game> games = GetGames();
IGrouping<DateTime, IEnumerable<Game>> groups = games.PartitionBy(game => game.ReleaseDate);
```

The `OrderBy` and `OrderByDescending` extension methods must allow forming a pipeline where multiple orders can be applied to a group of items; or to all groups at once.

```cs
List<Game> games = GetGames();
IGrouping<DateTime, IEnumerable<Game>> groups = games
    .PartitionBy(game => game.ReleaseDate)
    .OrderGroup(1985, game => game.Price)
    .OrderGroupDescending(1990, game => game.Rating)
    .OrderAllGroups(game => game.Name);
```

Finally, provide a method for joining back all groups into a single list, respecting the order of the groups and the order for the items within the groups.

```cs
List<Game> games = GetGames();
IOrderedEnumerable<Game> orderedGames = games
    .PartitionBy(game => game.ReleaseDate)
    .Flatten();
```

Keep the enumeration deferred until `.ToList()`. The extension methods shouldn't enumerate the elements or make any intermediate calls to `.ToList()` or similar. Neither they should create temporary copies of items or groups.

## Example

```cs
List<Game> games = GetGames();
IOrderedEnumerable<Game> orderedGames = games
    .PartitionBy(game => game.ReleaseDate);
        .OrderGroupDescending(1990, game => game.Rating)
        .OrderGroup(1995, game => game.Platform)
        .OrderGroup(2010, game => game.Price)
        .OrderAllGroups(game => game.Name)
    .Flatten()
    .ToList();
```

In the previous example:

1. `PartitionBy(game => game.ReleaseDate)` returns groups of games by release date

    ```js
    [
        { 1981, [ game1, game33, game47 ] },
        { 1990, [ game5, game17 ] },
        { 1996, [ game20, game28, game40, game41 ] },
    ]
    ```

2. `OrderGroupDescending(1990, game => game.Rating)` orders the group of games for year 1990 by rating in descending order

    ```js
    [
        // previous groups...
        {
            1990, // sorted by rating desc.
            [
                game17 { Rating: 10 },
                game5 { Rating: 7 }
            ]
        },
        // following groups...
    ]
    ```

3. `OrderGroup(1995, game => game.Platform)` and `OrderGroup(2010, game => game.Price)` order groups 1995 and 2010 respectively, in ascending order
4. `OrderAllGroups(game => game.Name)` orders all groups by game name, in ascending order

    Note that, this must be in addition to their previous order. i.e:

    - group 1990 must be sorted first by rating in descending order, then by name in ascending order
    - group 1995 must be sorted by platform in ascending order, then by name in ascending order
    - group 2010 must be sorted by price in ascending order, then by name in ascending order

    ```js
    {
        1995, // sorted by platform, then by name
        [
            game11 { Platform: "PS5", Name: "All Stars" },
            game12 { Platform: "PS5", Name: "Zelda" },
            game13 { Platform: "XBOX", Name: "All Stars" },
            game14 { Platform: "XBOX", Name: "OutRun" },
        ]
    },
    ```

5. `Flatten()` reduces, joins or combines all groups into a single ordered enumerable, which hasn't ordered the games yet because we have never called `.ToList()`

    ```js
    { game1, game2, game3, game4, game5 }
    ```

6. Finally, `.ToList()` enumerates the resulting `IOrderedEnumerable<Game>`, applying all order functions at the very end of the pipeline

    ```js
    [ game4, game2, game3, game5, game1 ]
    ```
