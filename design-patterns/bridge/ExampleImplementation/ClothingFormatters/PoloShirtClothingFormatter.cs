using DesignPatterns.Bridge.ExampleImplementation.ClothingItems;

namespace DesignPatterns.Bridge.ExampleImplementation.ClothingFormatters;

public class PoloShirtClothingFormatter(PoloShirt poloShirt) : IClothingFormatter
{
    private readonly PoloShirt _poloShirt = poloShirt;

    public string FormatDescription()
    {
        return $"A {_poloShirt.Color} {(_poloShirt.HasPocket ? "pocket" : string.Empty)} {_poloShirt.Material} polo shirt, size {_poloShirt.Size}";
    }

    public Uri FormatImageUrl()
    {
        return new Uri($"/images/polo_{_poloShirt.Brand.ToLowerInvariant().Replace(' ', '-')}_{_poloShirt.Color.ToLowerInvariant()}.jpg");
    }

    public string FormatTitle()
    {
        return $"{_poloShirt.Brand} Polo Shirt - Size {_poloShirt.Size}";
    }
}