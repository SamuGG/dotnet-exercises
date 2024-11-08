using DesignPatterns.Bridge.BasicImplementation;
using DesignPatterns.Bridge.ExampleImplementation.ClothingFormatters;
using DesignPatterns.Bridge.ExampleImplementation.ClothingItems;
using DesignPatterns.Bridge.ExampleImplementation.ClothingViews;

// Combine abstractions and implementions as you wish

Implementor implementor1 = new ConcreteImplementor1();
Implementor implementor2 = new ConcreteImplementor2();

Abstraction abstractionA = new RefinedAbstraction1(implementor1);
Abstraction abstractionB = new RefinedAbstraction1(implementor2);
Abstraction abstractionC = new RefinedAbstraction2(implementor1);
Abstraction abstractionD = new RefinedAbstraction2(implementor2);

// Get different results based on the combination chosen

abstractionA.UseImplementor();
abstractionB.UseImplementor();
abstractionC.UseImplementor();
abstractionD.UseImplementor();
Console.WriteLine();

// ---

var shoe = new Shoe("Nike", 8.5, "White", true, "Synthetic leather");
IClothingFormatter shoeFormatter = new ShoeClothingFormatter(shoe);
ClothingView shoeCompactView = new CompactClothingView(shoeFormatter);
shoeCompactView.Display();
Console.WriteLine();

ClothingView shoeMiniView = new MiniClothingView(shoeFormatter);
shoeMiniView.Display();
Console.WriteLine();

var poloShirt = new PoloShirt(36, "Red", "Cotton", true, "Ralph Lauren");
IClothingFormatter poloFormatter = new PoloShirtClothingFormatter(poloShirt);
ClothingView poloDetailedView = new DetailedClothingView(poloFormatter);
poloDetailedView.Display();
Console.WriteLine();

var dress = new Dress("Medium", "Green", "Night", "Silk");
IClothingFormatter dressFormatter = new DressClothingFormatter(dress);
ClothingView dressDetailedView = new DetailedClothingView(dressFormatter);
dressDetailedView.Display();
Console.WriteLine();
