namespace DesignPatterns.Observer.ExampleImplementation;

public sealed class ScoreUI(Player subject) : IGameObserver
{
    private readonly Player _subject = subject;

    public void Update()
    {
        int score = _subject.GetScore();
        Console.WriteLine($"Score: {score}");
    }
}