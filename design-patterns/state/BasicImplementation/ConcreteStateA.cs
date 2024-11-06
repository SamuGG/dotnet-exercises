namespace DesignPatterns.State.BasicImplementation;

public class ConcreteStateA : State
{
    public void Handle(Context context)
    {
        Console.WriteLine("Request handled by state A");
        context.SetState(new ConcreteStateB());
    }
}