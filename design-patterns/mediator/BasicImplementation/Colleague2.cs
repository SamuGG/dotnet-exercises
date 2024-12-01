namespace DesignPatterns.Mediator.BasicImplementation;

public sealed class Colleague2 : Colleague
{
    public void Operation2()
    {
        string @event = $"{nameof(Colleague2)} performed '{nameof(Operation2)}'";
        Console.WriteLine(@event);
        _mediator.Notify(this, @event);
    }

    public override void Receive(string @event)
    {
        Console.WriteLine($"{nameof(Colleague2)} received \"{@event}\"");
    }
}