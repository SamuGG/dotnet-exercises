using DesignPatterns.Builder.DirectorImplementation;
using DesignPatterns.Builder.DirectorImplementation.Builders;
using DesignPatterns.Builder.FluentImplementation;
using DesignPatterns.Builder.InnerImplementation;
using DesignPatterns.Builder.NestedImplementation;
using DesignPatterns.Builder.StepImplementation;

// Using a director
IBuilder builder = new SimpleProductBuilder();
ProductDirector director = new(builder);
director.ConstructProduct();
Product simpleProduct = builder.Build();
Console.WriteLine($"Using director with builder1, product: '{simpleProduct.Name}' - {simpleProduct.Description}");

builder = new ComplexProductBuilder();
director = new(builder);
director.ConstructProduct();
Product complexProduct = builder.Build();
Console.WriteLine($"Using director with builder2, product: '{complexProduct.Name}' - {complexProduct.Description}");
Console.WriteLine();

// Without a director
builder = new SimpleProductBuilder();
builder.BuildName();
builder.BuildDescription();
simpleProduct = builder.Build();
Console.WriteLine($"Building product without director: '{simpleProduct.Name}' - {simpleProduct.Description}");
Console.WriteLine();

// Nested builder
ProductWithBuilder.Builder nestedBuilder = new();
nestedBuilder.BuildName("Product 2");
nestedBuilder.BuildDescription("This is product 2");
ProductWithBuilder productWithBuilder = nestedBuilder.Build();
Console.WriteLine($"Building product from nested builder: '{productWithBuilder.Name}' - {productWithBuilder.Description}");
Console.WriteLine();

// Fluent builder
ProductWithFluentBuilder productWithFluentBuilder = new ProductWithFluentBuilder.Builder()
    .WithName("Product 3")
    .WithDescription("This is product 3")
    .Build();
Console.WriteLine($"Building product with fluent builder: '{productWithFluentBuilder.Name}' - {productWithFluentBuilder.Description}");
Console.WriteLine();

// Inner builder
Pizza pizza = new Pizza.Builder()
    .WithCheese(CheeseTypes.Mozzarella)
    .WithDough(dough => dough
        .WithFlour(PizzaBaseFlour.WholeWheat)
        .WithThickness(PizzaBaseThickness.Thin))
    .AddTopping("Ham")
    .WithSauce(SauceTypes.Tomato)
    .AddTopping("Chicken")
    .Build();

Console.Write($"{pizza.Dough.Thickness} pizza with {pizza.Dough.Flour} base, {pizza.Sauce} sauce, {pizza.Cheese} cheese");
if (pizza.Toppings.Count > 0)
    Console.WriteLine($", {string.Join(", ", pizza.Toppings)}");
Console.WriteLine();

// Step builder - enforces an order
StepPizza stepPizza = StepPizza.Builder.Begin()
    .WithDough(dough => dough
        .WithFlour(PizzaBaseFlour.Plain)
        .WithThickness(PizzaBaseThickness.Stuffed))
    .WithSauce(SauceTypes.Tomato)
    .WithCheese(CheeseTypes.ReducedFat)
    .AddTopping("Caramelised Onion")
    .AddTopping("Pepperoni")
    .Build();

Console.Write($"{stepPizza.Dough.Thickness} pizza with {stepPizza.Dough.Flour} base, {stepPizza.Sauce} sauce, {stepPizza.Cheese} cheese");
if (stepPizza.Toppings.Count > 0)
    Console.WriteLine($", {string.Join(", ", stepPizza.Toppings)}");
Console.WriteLine();