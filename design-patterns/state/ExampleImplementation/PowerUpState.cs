namespace DesignPatterns.State.ExampleImplementation;

public class PowerUpState : ICharacterState
{
    private int _powerUpDuration = 10; // ticks

    public void HandleDamage(Character character, int amount)
    {
        character.AddHealth(-(amount / 2));
    }

    public void HandlePowerUpCollected(Character character)
    {
        _powerUpDuration = 10;
    }

    public void HandleUpdate(Character character)
    {
        _powerUpDuration--;

        if (_powerUpDuration <= 0)
        {
            character.SetPowerUp(false);
            character.SetState(new NormalState());
        }
    }
}