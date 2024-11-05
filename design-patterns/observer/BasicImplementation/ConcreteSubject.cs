namespace DesignPatterns.Observer.BasicImplementation;

public class ConcreteSubject : Subject
{
    private static readonly List<Observer> _observers = [];

    private string _state = string.Empty;

    public void Attach(Observer observer)
    {
        _observers.Add(observer);
    }

    public void Detach(Observer observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (Observer observer in _observers)
            observer.Update();
    }

    public void SetState(string state)
    {
        _state = state;
        Notify();
    }

    public string GetState()
    {
        return _state;
    }
}
