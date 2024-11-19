using DesignPatterns.Composite.BasicImplementation;
using DesignPatterns.Composite.ExampleImplementation;

//     root
//     /   \
// leafA   composite
//          /     \
//      leafB     leafC

var root = new Composite();
var leafA = new Leaf();
root.Add(leafA);

var composite = new Composite();
var leafB = new Leaf();
var leafC = new Leaf();
composite.Add(leafB);
composite.Add(leafC);
root.Add(composite);

root.Operation();

// ---

var bundle = new Bundle("Design Patterns", 20.0);
var courseA = new Course("Composite Pattern", TimeSpan.FromHours(1.25), 99.0m);
var courseB = new Course("Singleton Pattern", TimeSpan.FromHours(1.5), 85.99m);
bundle.Add(courseA);
bundle.Add(courseB);

string bundleName = bundle.GetName();
TimeSpan bundleDuration = bundle.GetDuration();
decimal bundlePrice = bundle.GetPrice();

Console.WriteLine($"Bundle '{bundleName}' has a duration of {bundleDuration} and a price of {bundlePrice}");
Console.WriteLine($"While course '{courseA.GetName()}' has a price of {courseA.GetPrice()} and course '{courseB.GetName()}' has a price of {courseB.GetPrice()} when purchased individually");
