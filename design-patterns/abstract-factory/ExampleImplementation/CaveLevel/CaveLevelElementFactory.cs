using DesignPatterns.AbstractFactory.ExampleImplementation.Common;

namespace DesignPatterns.AbstractFactory.ExampleImplementation.CaveLevel;

public class CaveLevelElementFactory : LevelElementFactory
{
    public override IEnemy CreateEnemy()
    {
        return new Goblin();
    }

    public override IPowerUp CreatePowerUp()
    {
        return new Crystal();
    }

    public override IWeapon CreateWeapon()
    {
        return new Axe();
    }
}