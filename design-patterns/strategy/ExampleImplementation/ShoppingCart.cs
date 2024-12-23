namespace DesignPatterns.Strategy.ExampleImplementation;

public sealed class ShoppingCart
{
    private IPaymentStrategy? _strategy;

    public void SetStrategy(IPaymentStrategy strategy)
    {
        _strategy = strategy;
    }

    public void Checkout(decimal amount)
    {
        if (_strategy is null)
            return;

        _strategy.Pay(amount);
    }
}