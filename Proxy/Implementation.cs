using System;

namespace Proxy;

public class Document : IDocument
{
    public string? Title { get; private set; }
    public string? Content { get; private set; }
    public int AuthorId { get; private set; }
    public DateTimeOffset LastAccessed { get; private set; }

    private string _fileName;

    public Document(string fileName)
    {
        _fileName = fileName;
        LoadDocument(_fileName);
    }
    private void LoadDocument(string fileName)
    {
        Console.WriteLine("Executing expensive work: Loading file from disk...");
        Thread.Sleep(1000);

        Title = "An expensive document";
        Content = "Lots and Lots of content";
        AuthorId = 1;
        LastAccessed = DateTimeOffset.Now;
    }

    public void DisplayDucument()
    {
        Console.WriteLine($"File name: {_fileName}, Title: {Title}, Content: {Content}");
    }
}

public interface IDocument
{ 
    void DisplayDucument();
}

public class DocumentProxy : IDocument
{
    private string _fileName;
    public string FileName { get { return _fileName; } }

    private Lazy<Document> _document;

    public DocumentProxy(string fileName)
    {
        _fileName = fileName;
        _document = new Lazy<Document>(() => new Document(_fileName));
    }
    public void DisplayDucument()
    {
        _document.Value.DisplayDucument();
    }
}


public class ProtectedDocumentProxy : IDocument
{
    private string _fileName;
    public string FileName { get { return _fileName; } }

    private string _userRole;

    private DocumentProxy _documentProxy;

    public ProtectedDocumentProxy(string fileName, string userRole)
    {
        _fileName = fileName;
        _userRole = userRole;
        _documentProxy = new DocumentProxy(_fileName);
    }

    public void DisplayDucument()
    {
        if (_userRole == "read")
            _documentProxy.DisplayDucument();
        else
            Console.WriteLine($"Sorry you don't have access to open {_fileName}!");
    }
}
