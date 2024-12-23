using DesignPatterns.AbstractFactory.ExampleImplementation.Common;

namespace DesignPatterns.AbstractFactory.ExampleImplementation.HauntedHouseLevel;

public class HauntedHouseLevelElementFactory : LevelElementFactory
{
    public override IEnemy CreateEnemy()
    {
        return new Ghost();
    }

    public override IPowerUp CreatePowerUp()
    {
        return new Orb();
    }

    public override IWeapon CreateWeapon()
    {
        return new Staff();
    }
}