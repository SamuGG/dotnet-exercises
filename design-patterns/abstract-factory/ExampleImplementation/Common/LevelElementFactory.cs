namespace DesignPatterns.AbstractFactory.ExampleImplementation.Common;

public abstract class LevelElementFactory
{
    public abstract IEnemy CreateEnemy();
    public abstract IWeapon CreateWeapon();
    public abstract IPowerUp CreatePowerUp();

    public void SetupGameEnvironment()
    {
        IEnemy enemy = CreateEnemy();
        IWeapon weapon = CreateWeapon();
        IPowerUp powerUp = CreatePowerUp();
    }
}