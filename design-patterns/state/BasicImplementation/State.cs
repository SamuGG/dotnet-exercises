namespace DesignPatterns.State.BasicImplementation;

public interface State
{
    void Handle(Context context);
}