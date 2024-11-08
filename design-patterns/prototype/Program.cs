using DesignPatterns.Prototype.BasicImplementation;
using DesignPatterns.Prototype.ExampleImplementation;

var prototype1 = new ConcretePrototype1(75, 25, ["Layer1"]);
var shallowClone1 = prototype1.ShallowClone();
var deepClone1 = prototype1.DeepClone();
prototype1.Layers.Add("Layer2");
Console.WriteLine($"Prototype1.Layers: {prototype1.Layers.Count}, ShallowClone1.Layers: {shallowClone1.Layers.Count}, DeepClone1.Layers: {deepClone1.Layers.Count}");

var prototype2 = new ConcretePrototype2(80, ["Background1", "Background2"]);
var shallowClone2 = prototype2.ShallowClone();
var deepClone2 = prototype2.DeepClone();
prototype2.Layers.Remove("Background1");
Console.WriteLine($"Prototype2.Layers: {prototype2.Layers.Count}, ShallowClone2.Layers: {shallowClone2.Layers.Count}, DeepClone2.Layers: {deepClone2.Layers.Count}");

// ---

var rectangle = new Rectangle(100, 100, Color.LightGrey);
CopyDrag(rectangle);


static void CopyDrag(IShape shape)
{
    IShape newShape = shape.DeepClone();

    // while (mouseIsDown)
    //     DrawShape(newShape, mouse.Location);
}