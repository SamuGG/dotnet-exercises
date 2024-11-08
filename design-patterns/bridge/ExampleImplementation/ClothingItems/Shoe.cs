namespace DesignPatterns.Bridge.ExampleImplementation.ClothingItems;

public sealed record Shoe(string Brand, double Size, string Color, bool IsAthletic, string Material = "Leather");