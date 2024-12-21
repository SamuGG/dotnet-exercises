using DesignPatterns.Factory.ExampleImplementation.Enemies;

namespace DesignPatterns.Factory.ExampleImplementation.Levels;

public abstract class Level
{
    public abstract IEnemy CreateEnemy();

    public void EncounterEnemy()
    {
        IEnemy enemy = CreateEnemy();
        enemy.Scream();
        enemy.Attack();
    }
}