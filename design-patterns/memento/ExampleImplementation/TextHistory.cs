namespace DesignPatterns.Memento.ExampleImplementation;

public class TextHsitory
{
    private readonly Stack<TextBox.TextState> _undoStack = [];
    private readonly Stack<TextBox.TextState> _redoStack = [];

    public void Backup(TextBox.TextState state)
    {
        _undoStack.Push(state);
        _redoStack.Clear();
    }

    public void Undo(TextBox textBox)
    {
        if (_undoStack.Count < 1)
            return;

        _redoStack.Push(_undoStack.Pop());
        textBox.Restore(_undoStack.Peek());
    }

    public void Redo(TextBox textBox)
    {
        if (_redoStack.Count < 1)
            return;

        TextBox.TextState redoState = _redoStack.Pop();
        _undoStack.Push(redoState);
        textBox.Restore(redoState);
    }
}