using DesignPatterns.Observer.BasicImplementation;
using DesignPatterns.Observer.ExampleImplementation;

var subject = new ConcreteSubject();
subject.Attach(new ConcreteObserver(subject));
subject.Attach(new ConcreteObserver(subject));
subject.Attach(new ConcreteObserver(subject));

subject.SetState("First state");
await Task.Delay(TimeSpan.FromSeconds(1));
subject.SetState("Second state");
await Task.Delay(TimeSpan.FromSeconds(1));
subject.SetState("Third state");
Console.WriteLine();

// ---

var player = new Player();
player.Attach(new GameOverScreen(player));
player.Attach(new HealthBarUI(player));
player.Attach(new ScoreUI(player));

player.SetState(100, 0);
Console.WriteLine();
player.SetState(100, 10);
Console.WriteLine();
player.SetState(90, 20);
Console.WriteLine();
player.SetState(80, 30);
Console.WriteLine();
player.SetState(10, 25);
Console.WriteLine();
player.SetState(0, 25);
