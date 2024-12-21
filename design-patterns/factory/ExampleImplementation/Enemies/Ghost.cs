namespace DesignPatterns.Factory.ExampleImplementation.Enemies;

public class Ghost : IEnemy
{
    public void Attack()
    {
        Console.WriteLine($"{nameof(Ghost)} attacks");
    }

    public void Scream()
    {
        Console.WriteLine($"{nameof(Ghost)} screams");
    }
}