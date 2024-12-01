using DesignPatterns.Mediator.BasicImplementation;
using DesignPatterns.Mediator.ExampleImplementation;

var colleague1 = new Colleague1();
var colleague2 = new Colleague2();
Mediator mediator = new ConcreteMediator(colleague1, colleague2);

colleague1.Operation1();
colleague2.Operation2();
Console.WriteLine();

// ---

var alice = new AdminUser("Alice");
var bob = new RegularUser("Bob");
var charlie = new RegularUser("Charlie");

var chatRoom = new ChatRoom();
chatRoom.AddUser(alice);
chatRoom.AddUser(bob);
chatRoom.AddUser(charlie);

alice.Send("Welcome everybody!");
bob.Send("Hi everyone!");
charlie.Send("Hi Bob, how are you?");
bob.Send("I'm good thanks");
alice.BroadcastAlert("Keep it friendly guys");
