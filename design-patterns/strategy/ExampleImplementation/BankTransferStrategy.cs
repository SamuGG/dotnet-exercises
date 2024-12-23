namespace DesignPatterns.Strategy.ExampleImplementation;

public sealed record BankTransferStrategy(string AccountNumber) : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount:C} by bank transfer");
    }
}