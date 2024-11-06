using DesignPatterns.State.BasicImplementation;
using DesignPatterns.State.ExampleImplementation;

var context = new Context(new ConcreteStateA());

context.Request(); // State A (transitions to B)
context.Request(); // State B (transitions to A)
context.Request(); // State A (transitions to B)

// ---

var character = new Character();
Console.WriteLine($"Initial health: {character.Health}");
character.TakeDamage(30);
Console.WriteLine($"Health after damage: {character.Health}");
character.CollectPowerUp();
Console.WriteLine($"Health after power up: {character.Health}, has power up: {character.HasPowerUp}");
character.TakeDamage(30);
Console.WriteLine($"Health after 2nd damage: {character.Health}, has power up: {character.HasPowerUp}");

for (int i = 0; i < 12; i++)
    character.Update();

Console.WriteLine($"Health after 12 ticks: {character.Health}, has power up: {character.HasPowerUp}");

character.TakeDamage(30);
Console.WriteLine($"Health after damage: {character.Health}");

character.TakeDamage(70);
Console.WriteLine($"Health after damage: {character.Health}");
