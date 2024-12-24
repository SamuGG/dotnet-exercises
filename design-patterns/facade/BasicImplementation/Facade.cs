namespace DesignPatterns.Facade.BasicImplementation;

public sealed class Facade
{
    public void ComplexOperation()
    {
        Class1 class1 = new();
        Class2 class2 = new();
        Class3 class3 = new();
        Class4 class4 = new(class2);
        class4.Operation4(class3);
        class1.Operation1();
        class3.Operation3();
    }
}