namespace DesignPatterns.Mediator.ExampleImplementation;

public abstract class User(string name)
{
    protected IChatMediator _mediator = null!;

    public string Name { get; protected set; } = name;

    public void SetMediator(IChatMediator mediator)
    {
        _mediator = mediator;
    }

    public abstract void Send(string message);
    public abstract void Receive(string message, string sender);
}