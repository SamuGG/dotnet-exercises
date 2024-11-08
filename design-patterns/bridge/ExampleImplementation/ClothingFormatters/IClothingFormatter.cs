namespace DesignPatterns.Bridge.ExampleImplementation.ClothingFormatters;

public interface IClothingFormatter
{
    Uri FormatImageUrl();
    string FormatTitle();
    string FormatDescription();
}