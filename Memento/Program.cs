using Memento;

Console.Title = "Memento";

TextEditor textEditor = new TextEditor();

textEditor.MakeChange("Hello World!", 11);
Console.WriteLine(textEditor);

textEditor.MakeChange("Hello World! + Change 1", 17);
Console.WriteLine(textEditor);

textEditor.Undo();
Console.WriteLine(textEditor);
