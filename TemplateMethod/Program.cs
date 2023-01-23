using TemplateMethod;

Console.Title = "Template Method";

ExchangeMailParser exchangeMailParser = new();
Console.WriteLine(exchangeMailParser.ParseMail("6ba7b810-9dad-11d1-80b4-00c04fd430c8"));
Console.WriteLine();

ApacheMailParser apacheMailParser = new();
Console.WriteLine(apacheMailParser.ParseMail("6ba7b810-9dad-11d1-80b4-00c04fd430c8"));
Console.WriteLine();

EudoraMailParser eudoraMailParser = new();
Console.WriteLine(eudoraMailParser.ParseMail("6ba7b810-9dad-11d1-80b4-00c04fd430c8"));
