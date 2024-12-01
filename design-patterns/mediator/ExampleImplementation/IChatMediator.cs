namespace DesignPatterns.Mediator.ExampleImplementation;

public interface IChatMediator
{
    void Notify(User sender, string message);
}