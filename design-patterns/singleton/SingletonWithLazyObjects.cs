namespace DesignPatterns.Singleton;

public sealed class SingletonWithLazyObjects
{
    private SingletonWithLazyObjects()
    {
    }

    static SingletonWithLazyObjects()
    {
    }

    public static string Property1 = "Initialized 1st time any static field is accessed";
    public static SingletonWithLazyObjects Instance => NestedClass.Instance;

    private sealed class NestedClass
    {

        // This property only gets initialized when anyone accesses SingletonWithLazyObject.Instance
        // not when SingletonWithLazyObject.Property1 is accessed
        public static SingletonWithLazyObjects Instance => new();

        static NestedClass()
        {
        }
    }
}

// Accessing SingletonWithObjects.Property1 also initializes SingletonWithObjects.Instance
// as a NestedClass object but, doesn't initialize any of the nested properties yet.
//
// Only after accessing SingletonWithObjects.Instance, is when NestedClass.Instance field
// gets initialized (with any other static fields inside NestedClass).