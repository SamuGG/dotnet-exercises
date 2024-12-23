using DesignPatterns.Memento.BasicImplementation;
using DesignPatterns.Memento.ExampleImplementation;

// Originator originator = new();
// Caretaker caretaker = new();

// originator.SetState("State 1");
// caretaker.AddMemento(originator.CreateMemento());

// originator.SetState("State 2");
// caretaker.AddMemento(originator.CreateMemento());

// originator.SetState("State 3");
// caretaker.AddMemento(originator.CreateMemento());

// originator.Restore(caretaker.GetMemento(0));
// Console.WriteLine(originator.GetState());

// originator.Restore(caretaker.GetMemento(2));
// Console.WriteLine(originator.GetState());

// originator.Restore(caretaker.GetMemento(1));
// Console.WriteLine(originator.GetState());

// Console.WriteLine();

// ---

TextBox textBox = new();
TextHsitory history = new();

textBox.SetText("Hello");
history.Backup(textBox.Save());

textBox.SetText("Hello, world");
history.Backup(textBox.Save());

textBox.SetText("Hello world 2");
history.Backup(textBox.Save());

Console.WriteLine($"Current text: '{textBox.GetText()}'");

history.Undo(textBox);
Console.WriteLine($"After undo: '{textBox.GetText()}'");

history.Undo(textBox);
Console.WriteLine($"After 2nd undo: '{textBox.GetText()}'");

history.Redo(textBox);
Console.WriteLine($"After redo: '{textBox.GetText()}'");

history.Redo(textBox);
Console.WriteLine($"After 2nd redo: '{textBox.GetText()}'");