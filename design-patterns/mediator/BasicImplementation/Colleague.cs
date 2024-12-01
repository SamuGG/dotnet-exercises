namespace DesignPatterns.Mediator.BasicImplementation;

public abstract class Colleague
{
    protected Mediator _mediator = null!;

    public void SetMediator(Mediator mediator)
    {
        _mediator = mediator;
    }

    public abstract void Receive(string @event);
}