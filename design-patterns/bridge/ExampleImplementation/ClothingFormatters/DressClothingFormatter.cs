using DesignPatterns.Bridge.ExampleImplementation.ClothingItems;

namespace DesignPatterns.Bridge.ExampleImplementation.ClothingFormatters;

public class DressClothingFormatter(Dress dress) : IClothingFormatter
{
    private readonly Dress _dress = dress;

    public string FormatDescription()
    {
        return $"A {_dress.Color} {_dress.Material} {_dress.Style} dress, size {_dress.Size}";
    }

    public Uri FormatImageUrl()
    {
        return new Uri($"/images/dress_{_dress.Style.ToLowerInvariant().Replace(' ', '-')}_{_dress.Color.ToLowerInvariant()}.jpg");
    }

    public string FormatTitle()
    {
        return $"{_dress.Style} Dress - Size {_dress.Size}";
    }
}