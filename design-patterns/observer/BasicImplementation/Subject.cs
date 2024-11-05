namespace DesignPatterns.Observer.BasicImplementation;

public interface Subject
{
    void Attach(Observer observer);
    void Detach(Observer observer);
    void Notify();
}