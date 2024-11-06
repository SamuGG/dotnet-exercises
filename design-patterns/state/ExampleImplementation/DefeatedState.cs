namespace DesignPatterns.State.ExampleImplementation;

public class DefeateState : ICharacterState
{
    public void HandleDamage(Character character, int amount)
    {
        // Do nothing
    }

    public void HandlePowerUpCollected(Character character)
    {
        // Do nothing
    }

    public void HandleUpdate(Character character)
    {
        // Do nothing
    }
}