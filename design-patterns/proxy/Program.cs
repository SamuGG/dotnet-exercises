using DesignPatterns.Proxy.BasicImplementation;
using DesignPatterns.Proxy.VirtualProxy;

var proxy = new Proxy();
proxy.Operation();

Console.WriteLine();

var image = new ImageProxy("laptop");
image.Display(); // image placeholder
image.Display(); // full image

Console.WriteLine();