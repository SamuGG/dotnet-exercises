namespace DesignPatterns.State.ExampleImplementation;

public interface ICharacterState
{
    void HandleDamage(Character context, int amount);
    void HandlePowerUpCollected(Character context);
    void HandleUpdate(Character context);
}