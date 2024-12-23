namespace DesignPatterns.State.BasicImplementation;

public sealed class Context(State initialState)
{
    private State _state = initialState;

    public void SetState(State state)
    {
        _state = state;
    }

    public void Request()
    {
        _state.Handle(this);
    }
}