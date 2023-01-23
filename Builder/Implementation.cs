using System.Text;

namespace BuilderPattern;



public class Email
{
    private string _from, _to, _subject, _body;

    public Email(IEmailBuilder emailBuilder)
    {
        this._from = emailBuilder._from;
        this._to = emailBuilder._to;
        this._subject = emailBuilder._subject;
        this._body = emailBuilder._body;
    }

    public override string? ToString()
    {
        return $"Email ==> from: {_from}, to: {_to}, subject: {_subject}, body: {_body}";
    }
}


public interface IEmailBuilder : IFrom, ITo, ISubject, IBody, IBuildEmail
{
    public string _from { get; set; }
    public string _to { get; set; }
    public string _subject { get; set; }
    public string _body { get; set; }
}

public interface IFrom
{
    ITo From(string from);
}
public interface ITo
{
    ISubject To(string to);
}

public interface ISubject
{
    IBody Subject(string subject);
}

public interface IBody
{
    IBuildEmail Body(string body);
}

public interface IBuildEmail
{
    Email BuildEmail();
}


public class EmailBuilder : IEmailBuilder
{
    public string? _from { get; set;}
    public string? _to {get; set;}
    public string? _subject { get; set;}
    public string? _body { get; set;}

    public ITo From(string from)
    {
        this._from = from;
        // we can return this, because email builder implements ITo
        return this;
    }
    public ISubject To(string to)
    {
        this._to = to;
        return this;
    }
    public IBody Subject(string subject)
    {
        this._subject = subject;
        return this;
    }
    public IBuildEmail Body(string body)
    {
        this._body = body;
        return this;
    }
    public Email BuildEmail()
    {
        return new Email(this);
    }
}




