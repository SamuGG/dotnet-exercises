namespace DesignPatterns.Mediator.ExampleImplementation;

public sealed class RegularUser(string name) : User(name)
{
    public override void Send(string message)
    {
        Console.WriteLine($"{Name} sends: \"{message}\"");
        _mediator.Notify(this, message);
    }

    public override void Receive(string message, string sender)
    {
        Console.WriteLine($"{Name} received from {sender}: \"{message}\"");
    }
}