namespace DesignPatterns.Observer.BasicImplementation;

public class ConcreteObserver(ConcreteSubject subject) : Observer
{
    private readonly ConcreteSubject _subject = subject;

    public void Update()
    {
        string state = _subject.GetState();
        Console.WriteLine($"Observer reacted to state '{state}'");
    }
}
