namespace DesignPatterns.Factory.ExampleImplementation.Enemies;

public class Goblin : IEnemy
{
    public void Attack()
    {
        Console.WriteLine($"{nameof(Goblin)} attacks");
    }

    public void Scream()
    {
        Console.WriteLine($"{nameof(Goblin)} screams");
    }
}