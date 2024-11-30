namespace DesignPatterns.Adapter.ExampleImplementation;

public interface IRectangle
{
    long GetArea();
    long GetPerimeter();
    void Move(long dx, long dy);
}