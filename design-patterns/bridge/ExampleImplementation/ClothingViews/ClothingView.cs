using DesignPatterns.Bridge.ExampleImplementation.ClothingFormatters;

namespace DesignPatterns.Bridge.ExampleImplementation.ClothingViews;

public abstract class ClothingView(IClothingFormatter clothingFormatter)
{
    public IClothingFormatter ClothingFormatter { get; init; } = clothingFormatter;

    public abstract void Display();
}