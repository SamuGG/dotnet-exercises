namespace DesignPatterns.Observer.ExampleImplementation;

public class Player : IGameSubject
{
    private static readonly List<IGameObserver> _observers = [];

    private int _health;
    private int _score;

    public void Attach(IGameObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IGameObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (IGameObserver observer in _observers)
            observer.Update();
    }

    public void SetState(int health, int score)
    {
        _health = health;
        _score = score;
        Notify();
    }

    public int GetHealth()
    {
        return _health;
    }

    public int GetScore()
    {
        return _score;
    }
}