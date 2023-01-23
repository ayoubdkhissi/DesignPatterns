using BuilderPattern;

Console.Title = "Builder";

IEmailBuilder emailBuilder = new EmailBuilder();

Email email = emailBuilder
    .From("Ayoub")
    .To("Ali")
    .Subject("DP")
    .Body("Design Patterns Are great")
    .BuildEmail();

Console.WriteLine(email);

Console.ReadLine();
