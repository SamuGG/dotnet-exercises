namespace DesignPatterns;

public sealed class SingletonWithValues
{
    private SingletonWithValues()
    {
    }

    static SingletonWithValues()
    {
    }

    public static string Property1 = "Initialized 1st time any static field is accessed";
    public static string Property2 = "Initialized 1st time any static field is accessed";
}

// Accessing SingletonWithValues.Property1 also initializes the value or SingletonWithValues.Property2, and vice-versa