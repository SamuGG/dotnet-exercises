namespace DesignPatterns.Observer.ExampleImplementation;

public sealed class GameOverScreen(Player subject) : IGameObserver
{
    private readonly Player _subject = subject;

    public void Update()
    {
        if (_subject.GetHealth() <= 0)
            Console.WriteLine("Game over");
    }
}