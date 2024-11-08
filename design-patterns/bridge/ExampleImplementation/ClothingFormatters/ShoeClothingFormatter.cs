using DesignPatterns.Bridge.ExampleImplementation.ClothingItems;

namespace DesignPatterns.Bridge.ExampleImplementation.ClothingFormatters;

public class ShoeClothingFormatter(Shoe shoe) : IClothingFormatter
{
    private readonly Shoe _shoe = shoe;

    public string FormatDescription()
    {
        return $"A {_shoe.Color} {(_shoe.IsAthletic ? "athletic" : string.Empty)} {_shoe.Material} shoe, size {_shoe.Size}";
    }

    public Uri FormatImageUrl()
    {
        return new Uri($"/images/shoe_{_shoe.Brand.ToLowerInvariant().Replace(' ', '-')}_{_shoe.Color.ToLowerInvariant()}.jpg");
    }

    public string FormatTitle()
    {
        return $"{_shoe.Brand} Shoe - Size {_shoe.Size}";
    }
}