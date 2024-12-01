namespace DesignPatterns.Mediator.BasicImplementation;

public sealed class Colleague1 : Colleague
{
    public void Operation1()
    {
        string @event = $"{nameof(Colleague1)} performed '{nameof(Operation1)}'";
        Console.WriteLine(@event);
        _mediator.Notify(this, @event);
    }

    public override void Receive(string @event)
    {
        Console.WriteLine($"{nameof(Colleague1)} received \"{@event}\"");
    }
}