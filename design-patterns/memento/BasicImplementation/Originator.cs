namespace DesignPatterns.Memento.BasicImplementation;

public sealed class Originator
{
    private string _state = string.Empty;

    public string GetState()
    {
        return _state;
    }

    public void SetState(string newState)
    {
        _state = newState;
    }

    public Memento CreateMemento()
    {
        return new Memento(_state);
    }

    public void Restore(Memento memento)
    {
        _state = memento.GetState();
    }

    public sealed class Memento
    {
        private readonly string _state;

        internal Memento(string state)
        {
            _state = state;
        }

        internal string GetState()
        {
            return _state;
        }
    }
}