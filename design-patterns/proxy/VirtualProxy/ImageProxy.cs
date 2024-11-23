namespace DesignPatterns.Proxy.VirtualProxy;

public sealed class ImageProxy(string fileName) : IImage
{
    private readonly string _fileName = fileName;
    private RealImage? _realImage = null;

    private static readonly string _lowResolutionPlaceholder = """
   +--------------+
   |.------------.|
   ||            ||
   ||            ||
   ||            ||
   ||            ||
   |+------------+|
   +-..--------..-+
   .--------------.
  / /============\ \
 / /==============\ \
/____________________\
\____________________/
""";

    public void Display()
    {
        if (_realImage is { })
        {
            _realImage.Display();
            return;
        }

        Console.WriteLine($"Displaying low resolution placeholder for '{_fileName}'");
        Console.WriteLine(_lowResolutionPlaceholder);
        _realImage = new(_fileName);
    }
}