namespace Memento;

public class Memento
{
    public string Text { get; private set; }
    public int CursorPosition { get; private set; }

    public Memento(string text, int cursorPosition)
    {
        Text = text;
        CursorPosition = cursorPosition;
    }
}

public class Originator
{
    public string Text { get; set; } = String.Empty;
    public int CursorPosition { get; set; }

    public Memento CreateMemento()
    {
        return new Memento(Text, CursorPosition);
    }

    public void SetMemento(Memento memento)
    {
        Text = memento.Text;
        CursorPosition = memento.CursorPosition;
    }
}

public class Caretaker
{
    private readonly Stack<Memento> mementos;

    public Caretaker()
    {
        mementos = new Stack<Memento>();
    }

    public void Save(Originator originator)
    {
        mementos.Push(originator.CreateMemento());
    }

    public void Undo(Originator originator)
    {
        if (mementos.Count > 0)
        {
            originator.SetMemento(mementos.Pop());
        }
    }
}

public class TextEditor
{
    private readonly Originator originator;
    private readonly Caretaker caretaker;

    public TextEditor()
    {
        originator = new Originator();
        caretaker = new Caretaker();
    }

    public void MakeChange(string text, int cursorPosition)
    {
        caretaker.Save(originator);
        originator.Text = text;
        originator.CursorPosition = cursorPosition;
    }

    public void Undo()
    {
        caretaker.Undo(originator);
    }

    public override string? ToString()
    {
        return $"Text: {originator.Text}, cursor position: {originator.CursorPosition}";
    }
}