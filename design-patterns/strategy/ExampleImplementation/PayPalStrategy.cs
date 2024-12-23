namespace DesignPatterns.Strategy.ExampleImplementation;

public sealed record PayPalStrategy(string EmailAddress) : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount:C} from Paypal");
    }
}