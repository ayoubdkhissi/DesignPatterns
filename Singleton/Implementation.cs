namespace Singleton;


public class Logger
{

    private static readonly Lazy<Logger> _lazyLogger
        = new Lazy<Logger>(() => new Logger());

    // private static Logger? _instance;
    public static Logger Instance
    {
        get
        {
            return _lazyLogger.Value;  
        }
    }
    private Logger() { }
    public void Log(string message)
    {
        Console.WriteLine($"{DateTime.UtcNow}: {message}");
    }
    
}
