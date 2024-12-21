using DesignPatterns.Factory.ExampleImplementation.Enemies;

namespace DesignPatterns.Factory.ExampleImplementation.Levels;

public class CaveLevel : Level
{
    public override IEnemy CreateEnemy()
    {
        return new Goblin();
    }
}