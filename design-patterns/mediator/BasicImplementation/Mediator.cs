namespace DesignPatterns.Mediator.BasicImplementation;

public interface Mediator
{
    void Notify(Colleague sender, string @event);
}