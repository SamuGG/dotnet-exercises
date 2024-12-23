namespace DesignPatterns.Strategy.BasicImplementation;

public sealed class Context
{
    private Strategy? _strategy;

    public void SetStrategy(Strategy strategy)
    {
        _strategy = strategy;
    }

    public void ExecuteStrategy()
    {
        if (_strategy is null)
            return;

        _strategy.Execute();
    }
}