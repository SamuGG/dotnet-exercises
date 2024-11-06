namespace DesignPatterns.State.BasicImplementation;

public class ConcreteStateB : State
{
    public void Handle(Context context)
    {
        Console.WriteLine("Request handled by state B");
        context.SetState(new ConcreteStateA());
    }
}