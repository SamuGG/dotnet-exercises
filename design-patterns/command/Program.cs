using DesignPatterns.Command.BasicImplementation;
using DesignPatterns.Command.ExampleImplementation;

Receiver receiver = new();
Command command1 = new ConcreteCommand(receiver, "1");
Command command2 = new ConcreteCommand(receiver, "2");
Command command3 = new ConcreteCommand(receiver, "3");

Invoker invoker = new();
invoker.AddCommand(command1);
invoker.AddCommand(command2);
invoker.AddCommand(command3);

invoker.ExecuteCommands();
invoker.UndoLastCommand();
invoker.UndoLastCommand();

Console.WriteLine();

// ---

FileSystemReceiver fileSystemReceiver = new();
CLI cli = new();
cli.RegisterCommand("ls", new ListDirectoryCommand(fileSystemReceiver));
cli.RegisterCommand("cd", new ChangeDirectoryCommand(fileSystemReceiver));
cli.RegisterCommand("mkdir", new MakeDirectoryCommand(fileSystemReceiver));

cli.ExecuteCommand("mkdir", ["directory_1"]);
cli.ExecuteCommand("cd", ["directory_1"]);
cli.ExecuteCommand("ls", []);
cli.ExecuteCommand("ls", ["directory_1"]);

cli.ExecuteCommand("123", []);
cli.ExecuteCommand("cd", []);
