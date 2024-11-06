namespace DesignPatterns.State.ExampleImplementation;

public sealed class Character
{
    private ICharacterState _state = new NormalState();

    public int Health { get; private set; } = 100;
    public bool HasPowerUp { get; private set; }

    public void AddHealth(int amount)
    {
        Health = Math.Clamp(Health + amount, 0, 100);
    }

    public void SetPowerUp(bool value)
    {
        HasPowerUp = value;
    }

    public void SetState(ICharacterState state)
    {
        Console.WriteLine($"Switching to state '{state.GetType().Name}'");
        _state = state;
    }

    public void TakeDamage(int amount)
    {
        _state.HandleDamage(this, amount);
    }

    public void CollectPowerUp()
    {
        _state.HandlePowerUpCollected(this);
    }

    public void Update()
    {
        _state.HandleUpdate(this);
    }
}