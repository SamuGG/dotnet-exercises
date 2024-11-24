using DesignPatterns.Decorator.BasicImplementation;
using DesignPatterns.Decorator.ExampleImplementation;

var component1 = new ConcreteComponent();
component1.Operation();
Console.WriteLine();

var component2 = new ConcreteDecorator1(new ConcreteComponent());
component2.Operation();
Console.WriteLine();

var component3 = new ConcreteDecorator1(new ConcreteDecorator1(new ConcreteComponent()));
component3.Operation();
Console.WriteLine();

var component4 = new ConcreteDecorator2(new ConcreteDecorator1(new ConcreteDecorator1(new ConcreteComponent())));
component4.Operation();
Console.WriteLine();

// ---

var car1 = new BasicTeslaModel();
PrintCarDetails(car1);

var car2 = new RedPaintTeslaDecorator(new BasicTeslaModel());
PrintCarDetails(car2);

var car3 = new BluePaintTeslaDecorator(new BasicTeslaModel());
PrintCarDetails(car3);

var car4 = new LongRangeTeslaDecorator(new RedPaintTeslaDecorator(new BasicTeslaModel()));
PrintCarDetails(car4);

static void PrintCarDetails(ITeslaCar car)
{
    Console.WriteLine($"Description: {car.GetDescription()}");
    Console.WriteLine($"Range: {car.GetRangeInKm()} km");
    Console.WriteLine($"Price: {car.GetPrice():c}");
    Console.WriteLine();
}