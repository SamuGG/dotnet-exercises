namespace DesignPatterns.Bridge.ExampleImplementation.ClothingItems;

public sealed record PoloShirt(double Size, string Color, string Material, bool HasPocket = false, string Brand = "Generic");