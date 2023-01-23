using Singleton;

Logger logger1 = Logger.Instance;
Logger logger2 = Logger.Instance;

Console.WriteLine($"Hash-Code of instance 1: {logger1.GetHashCode()}");
Console.WriteLine($"Hash-Code of instance 2: {logger2.GetHashCode()}");