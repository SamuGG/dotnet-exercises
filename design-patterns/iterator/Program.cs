using DesignPatterns.Iterator.BasicImplementation;
using DesignPatterns.Iterator.DotNetImplementation;

UseBasicImplementation();
UseEnumerator();

static void UseBasicImplementation()
{
    Console.WriteLine("Using basic iterator");
    Aggregate<int> aggregate = new ConcreteAggregate<int>();
    aggregate.Add(1);
    aggregate.Add(2);
    aggregate.Add(3);

    Iterator<int> iterator = aggregate.CreateIterator();

    while (iterator.HasNext())
        Console.WriteLine(iterator.Next());

    iterator.Reset();
    Console.WriteLine();

    while (iterator.HasNext())
        Console.WriteLine(iterator.Next());

    Console.WriteLine();
}

static void UseEnumerator()
{
    Console.WriteLine("Using .NET Enumerator");
    MyCollection<int> aggregate = [1, 2, 3];

    // foreach internally gets the enumerator and iterates over the collection
    foreach (int element in aggregate)
        Console.WriteLine(element);

    Console.WriteLine();

    // Alternatively, we can use the enumerator manually like so
    IEnumerator<int> enumerator = aggregate.GetEnumerator();

    while (enumerator.MoveNext())
        Console.WriteLine(enumerator.Current);

    enumerator.Reset();
    Console.WriteLine();
}