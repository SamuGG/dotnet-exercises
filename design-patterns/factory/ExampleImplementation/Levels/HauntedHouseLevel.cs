using DesignPatterns.Factory.ExampleImplementation.Enemies;

namespace DesignPatterns.Factory.ExampleImplementation.Levels;

public class HauntedHouseLevel : Level
{
    public override IEnemy CreateEnemy()
    {
        return new Ghost();
    }
}