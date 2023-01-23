namespace Decorator;

public interface IMailService
{
    bool SendEmail(string message);
}


public class CloudMailService : IMailService
{
    public bool SendEmail(string message)
    {
        Console.WriteLine($"Message: {message} \n Sent by Cloud Mail Service");
        return true;
    }
}

public class OnPremiseMailService : IMailService
{
    public bool SendEmail(string message)
    {
        Console.WriteLine($"Message: {message} \n Sent by OnPremise Mail Service");
        return true;
    }
}

public abstract class MailServiceDecoratorBase : IMailService
{
    private readonly IMailService _mailService;

    public MailServiceDecoratorBase(IMailService mailService)
    {
        _mailService = mailService;
    }

    public virtual bool SendEmail(string message)
    {
        return _mailService.SendEmail(message);
    }
}

public class StatisticsMailDecorator : MailServiceDecoratorBase
{
    public StatisticsMailDecorator(IMailService mailService) : base(mailService)
    {
    }
    public override bool SendEmail(string message)
    {
        // Fake collecting statistics
        Console.WriteLine($"Collecting statistics in {nameof(StatisticsMailDecorator)}");
        return base.SendEmail(message);
    }
}

public class DatabaseMailDecorator : MailServiceDecoratorBase
{
    public List<string> SentMails { get; private set; } = new List<string>();
    public DatabaseMailDecorator(IMailService mailService) : base(mailService)
    {
    }
    public override bool SendEmail(string message)
    {
        // Fake storing mail in database
        Console.WriteLine($"Storing mail in the database");
        
        if(base.SendEmail(message))
        {
            SentMails.Add(message);
            return true;
        }
        return false;
    }
}
