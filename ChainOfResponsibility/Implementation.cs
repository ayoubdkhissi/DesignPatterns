using System.ComponentModel.DataAnnotations;

namespace ChainOfResponsibility;

public class Document
{
    public string Title { get; set; }
    public DateTimeOffset LastModified { get; set; }
    public bool ApprovedByLitigation { get; set; }
    public bool ApprovedByManagement { get; set; }

    public Document(string title, 
        DateTimeOffset lastModified, 
        bool approvedByLitigation, 
        bool approvedByManagement)
    {
        Title = title;
        LastModified = lastModified;
        ApprovedByLitigation = approvedByLitigation;
        ApprovedByManagement = approvedByManagement;
    }
}

public interface IHandler<T> where T : class
{
    IHandler<T> SetSuccessor(IHandler<T> successor);
    void Handle(T request);
}

public class DocumentTitleHandler : IHandler<Document>
{
    private IHandler<Document>? _successor;

    public void Handle(Document document)
    {
        if(document.Title == string.Empty)
        {
            throw new ValidationException(
                new ValidationResult(
                    "Titile must be filled out",
                    new List<string>() { "Title"}), null, null);
        }

        // go to the next handler
        _successor?.Handle(document);
    }

    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor;
        return successor;
    }
}

public class DocumentLastModifiedHandler : IHandler<Document>
{
    private IHandler<Document>? _successor;

    public void Handle(Document document)
    {
        if (document.LastModified < DateTime.UtcNow.AddDays(-30))
        {
            throw new ValidationException(
                new ValidationResult(
                    "Document must be modified in the last 30 days",
                    new List<string>() { "LastModified" }), null, null);
        }

        // go to the next handler
        _successor?.Handle(document);
    }

    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor;
        return successor;
    }
}

public class DocumentApprovedByLitigationHandler : IHandler<Document>
{
    private IHandler<Document>? _successor;

    public void Handle(Document document)
    {
        if (!document.ApprovedByLitigation)
        {
            throw new ValidationException(
                new ValidationResult(
                    "Document must be approved by Litigation",
                    new List<string>() { "ApprovedByLitigation" }), null, null);
        }

        // go to the next handler
        _successor?.Handle(document);
    }

    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor;
        return successor;
    }
}

public class DocumentApprovedByManagementHandler : IHandler<Document>
{
    private IHandler<Document>? _successor;

    public void Handle(Document document)
    {
        if (!document.ApprovedByManagement)
        {
            throw new ValidationException(
                new ValidationResult(
                    "Document must be approved by Management",
                    new List<string>() { "ApprovedByManagement" }), null, null);
        }

        // go to the next handler
        _successor?.Handle(document);
    }

    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor;
        return successor;
    }
}
