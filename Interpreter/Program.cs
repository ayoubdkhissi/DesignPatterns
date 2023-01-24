using Interpreter;

Console.Title = "Interpreter";

// creating the syntax tree
var expressions = new List<RomanExpression>
{
    new RomanThousandExpression(),
    new RomanHundredExpression(),
    new RomanTenExpression(),
    new RomanOneExpression()
};

var context = new RomanContext(1819);

foreach(var expression in expressions)
{
    expression.Interpret(context);
}

Console.WriteLine($"1819 = {context.Output}");