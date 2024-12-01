namespace DesignPatterns.Mediator.BasicImplementation;

public class ConcreteMediator : Mediator
{
    private readonly Colleague _colleague1;
    private readonly Colleague _colleague2;

    public ConcreteMediator(Colleague colleague1, Colleague colleague2)
    {
        _colleague1 = colleague1;
        _colleague1.SetMediator(this);

        _colleague2 = colleague2;
        _colleague2.SetMediator(this);
    }

    public void Notify(Colleague sender, string @event)
    {
        Console.WriteLine($"{nameof(ConcreteMediator)} notified by '{sender.GetType().Name}'");

        if (ReferenceEquals(sender, _colleague1))
            _colleague2.Receive(@event);
        else
            _colleague1.Receive(@event);
    }
}