using DesignPatterns.Strategy.BasicImplementation;
using DesignPatterns.Strategy.ExampleImplementation;

Context context = new();
context.SetStrategy(new ConcreteStrategyA());
context.ExecuteStrategy();
context.SetStrategy(new ConcreteStrategyB());
context.ExecuteStrategy();

Console.WriteLine();

// ---

ShoppingCart shoppingCart = new();
shoppingCart.SetStrategy(new CreditCardStrategy("John Doe", "2143 6875 4653 3612", "000"));
shoppingCart.Checkout(74.95m);
shoppingCart.SetStrategy(new PayPalStrategy("john.doe@test.com"));
shoppingCart.Checkout(29.99m);
shoppingCart.SetStrategy(new BankTransferStrategy("123456 012345678"));
shoppingCart.Checkout(20.50m);