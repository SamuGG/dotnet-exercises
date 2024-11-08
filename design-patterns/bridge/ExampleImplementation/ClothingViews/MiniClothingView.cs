using DesignPatterns.Bridge.ExampleImplementation.ClothingFormatters;

namespace DesignPatterns.Bridge.ExampleImplementation.ClothingViews;

public class MiniClothingView(IClothingFormatter clothingFormatter) : ClothingView(clothingFormatter)
{
    public override void Display()
    {
        Console.WriteLine("Mini view:");
        Console.WriteLine($"Title: {ClothingFormatter.FormatTitle()}");
    }
}