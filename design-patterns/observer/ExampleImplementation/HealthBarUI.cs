namespace DesignPatterns.Observer.ExampleImplementation;

public sealed class HealthBarUI(Player subject) : IGameObserver
{
    private readonly Player _subject = subject;

    public void Update()
    {
        int health = _subject.GetHealth();
        Console.WriteLine($"Health: {health}");
    }
}