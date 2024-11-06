namespace DesignPatterns.State.ExampleImplementation;

public class InjuredState : ICharacterState
{
    public void HandleDamage(Character character, int amount)
    {
        character.AddHealth(-(amount * 2));

        if (character.Health <= 0)
            character.SetState(new DefeateState());
    }

    public void HandlePowerUpCollected(Character character)
    {
        character.AddHealth(50);
        character.SetState(new NormalState());
    }

    public void HandleUpdate(Character character)
    {
        character.AddHealth(2);

        if (character.Health >= 30)
            character.SetState(new NormalState());
    }
}