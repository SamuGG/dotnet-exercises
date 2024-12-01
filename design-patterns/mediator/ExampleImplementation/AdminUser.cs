namespace DesignPatterns.Mediator.ExampleImplementation;

public sealed class AdminUser(string name) : User(name)
{
    public override void Send(string message)
    {
        Console.WriteLine($"Admin {Name} announces: \"{message}\"");
        _mediator.Notify(this, $"ADMIN MESSAGE: {message}");
    }

    public override void Receive(string message, string sender)
    {
        Console.WriteLine($"Admin {Name} received from {sender}: \"{message}\"");
    }

    public void BroadcastAlert(string message)
    {
        Console.WriteLine($"Admin {Name} broadcasts: \"{message}\"");
        _mediator.Notify(this, $"ADMIN ALERT: {message}");
    }
}