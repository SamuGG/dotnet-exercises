using DesignPatterns.Bridge.ExampleImplementation.ClothingFormatters;

namespace DesignPatterns.Bridge.ExampleImplementation.ClothingViews;

public class CompactClothingView(IClothingFormatter clothingFormatter) : ClothingView(clothingFormatter)
{
    public override void Display()
    {
        Console.WriteLine("Compact view:");
        Console.WriteLine($"Title: {ClothingFormatter.FormatTitle()}");
        Console.WriteLine($"Image: {ClothingFormatter.FormatImageUrl()}");
    }
}