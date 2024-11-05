namespace DesignPatterns.Singleton;

public sealed class SingletonWithObjects
{
    private SingletonWithObjects()
    {
    }

    static SingletonWithObjects()
    {
    }

    public static string Property1 = "Initialized 1st time any static field is accessed";

    // This property gets initialized when anyone accesses SingletonWithObjects.Property1
    public static SingletonWithObjects Instance => new();
}

// Accessing SingletonWithObjects.Property1 also initializes SingletonWithObjects.Instance, and vice-versa