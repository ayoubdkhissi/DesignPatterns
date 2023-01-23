namespace TemplateMethod;

public abstract class MailParser
{
    public virtual void FindServer()
    {
        Console.WriteLine("Finding a server...");
    }

    public abstract void AuthenticateToServer();

    public string ParseHtmlMailBody(string identifier)
    {
        Console.WriteLine("Parsing HTML mail body...");
        return $"this is the body of the mail with id {identifier}";
    }

    public string ParseMail(string identifier)
    {
        Console.WriteLine("Parsing Mail (template method)...");
        FindServer();
        AuthenticateToServer();
        return ParseHtmlMailBody(identifier);
    }
}

public class ExchangeMailParser : MailParser
{
    public override void AuthenticateToServer()
    {
        Console.WriteLine("Authenticating to Exchange Server...");
    }
}

public class ApacheMailParser : MailParser
{
    public override void AuthenticateToServer()
    {
        Console.WriteLine("Authenticating to Apache Server...");
    }
}

public class EudoraMailParser : MailParser
{

    public override void FindServer()
    {
        Console.WriteLine("Finding a Eudora server through a custom algorithm...");
    }
    public override void AuthenticateToServer()
    {
        Console.WriteLine("Authenticating to Eudora Server...");
    }
}
