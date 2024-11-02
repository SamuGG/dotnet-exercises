using Linq01.Extensions02;

namespace Linq01;

internal sealed record Game(string Name, int ReleaseDate, int Rating);

internal sealed class Program
{
    private static void Main(string[] args)
    {
        Game[] games =
        [
            new("Super Mario Bros.", 1985, 9),
            new("Super Mario Bros. 2", 1988, 8),
            new("Super Mario Bros. 3", 1990, 10),
            new("Super Mario World", 1991, 10),
            new("Super Mario Land", 1989, 7),
            new("Super Mario Land 2", 1992, 9),
            new("Super Mario 64", 1996, 10),
            new("Super Mario Sunshine", 2002, 8),
            new("Super Mario Galaxy", 2007, 10),
            new("Super Mario Galaxy 2", 2010, 10),
            new("Super Mario 3D World", 2013, 9),
            new("Super Mario Odyssey", 2017, 10),
            new("Sonic the Hedgehog", 1991, 8),
            new("Sonic the Hedgehog 2", 1992, 9),
            new("Sonic the Hedgehog 3", 1994, 7),
            new("Sonic & Knuckles", 1994, 9),
            new("Sonic Adventure", 1998, 8),
            new("Sonic Adventure 2", 2001, 8),
            new("Sonic Heroes", 2003, 7),
            new("Sonic Unleashed", 2008, 7),
        ];

        // Extensions01
        // var orderedGames = games
        //     .Partition(game => game.Name.Contains("Mario"))
        //     .OrderGroup(true, games => games.OrderBy(game => game.ReleaseDate))
        //     .OrderGroup(false, games => games.OrderByDescending(game => game.ReleaseDate))
        //     .OrderAllGroups(games => games.OrderBy(game => game.Name))
        //     .OrderGroupWhen(() => true, false, games => games.OrderByDescending(game => game.Rating))
        //     .ConcatGroups()
        //     .ToList();

        // Extensions02
        var orderedGames = games
            .Partition(game => game.Name.StartsWith("Sonic"))
            .OrderGroupDescending(true, game => game.Rating)
            .OrderAllGroups(game => game.Name)
            .ConcatGroups()
            .ToArray();

        foreach (Game game in orderedGames)
            Console.WriteLine($"{game.Name} ({game.ReleaseDate}) - {game.Rating}");
    }
}
