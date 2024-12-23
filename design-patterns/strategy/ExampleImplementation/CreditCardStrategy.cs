namespace DesignPatterns.Strategy.ExampleImplementation;

public sealed record CreditCardStrategy(string CarHolderName, string CardNumber, string Cvv) : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount:C} by credit card");
    }
}