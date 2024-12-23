namespace DesignPatterns.Memento.ExampleImplementation;

public sealed class TextBox
{
    private string _text = string.Empty;

    public string GetText()
    {
        return _text;
    }

    public void SetText(string text)
    {
        _text = text;
    }

    public TextState Save()
    {
        return new TextState(_text);
    }

    public void Restore(TextState state)
    {
        _text = state.GetText();
    }

    public sealed class TextState
    {
        private readonly string _text;

        internal TextState(string text)
        {
            _text = text;
        }

        internal string GetText()
        {
            return _text;
        }
    }
}