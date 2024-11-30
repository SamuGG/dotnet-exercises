using DesignPatterns.Adapter.BasicImplementation;
using DesignPatterns.Adapter.ExampleImplementation;

var adaptee = new Adaptee();
Target adapter = new Adapter(adaptee);
adapter.Request();

// ---

var legacyRectangle = new LegacyRectangle(200, 50, 150, 25);
IRectangle rectangleAdapter = new LegacyRectangleAdapter(legacyRectangle);
CenterRectangle(rectangleAdapter);

static void CenterRectangle(IRectangle rectangle)
{
    rectangle.Move(-100, -50);
}