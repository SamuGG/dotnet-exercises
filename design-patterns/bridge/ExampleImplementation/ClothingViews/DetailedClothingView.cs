using DesignPatterns.Bridge.ExampleImplementation.ClothingFormatters;

namespace DesignPatterns.Bridge.ExampleImplementation.ClothingViews;

public class DetailedClothingView(IClothingFormatter clothingFormatter) : ClothingView(clothingFormatter)
{
    public override void Display()
    {
        Console.WriteLine("Detailed view:");
        Console.WriteLine($"Title: {ClothingFormatter.FormatTitle()}");
        Console.WriteLine($"Image: {ClothingFormatter.FormatImageUrl()}");
        Console.WriteLine($"Description: {ClothingFormatter.FormatDescription()}");
    }
}