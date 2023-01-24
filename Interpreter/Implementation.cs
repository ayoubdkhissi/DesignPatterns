namespace Interpreter;

// Context
public class RomanContext
{
    public int Input { get; set; }

    public String Output { get; set; } = String.Empty;

    public RomanContext(int input)
    {
        Input = input;
    }
}

// Abstract Expression
public abstract class RomanExpression
{
    public abstract void Interpret(RomanContext value);
}

// Terminal Expression
public class RomanOneExpression : RomanExpression
{
    public override void Interpret(RomanContext value)
    {
        while (value.Input >= 1)
        {
            if (value.Input >= 9)
            {
                value.Output += "IX";
                value.Input -= 9;
            }
            else if (value.Input >= 5)
            {
                value.Output += "V";
                value.Input -= 5;
            }
            else if (value.Input >= 4)
            {
                value.Output += "IV";
                value.Input -= 4;
            }
            else
            {
                value.Output += "I";
                value.Input -= 1;
            }
        }
    }
}

public class RomanTenExpression : RomanExpression
{
    public override void Interpret(RomanContext value)
    {
        while (value.Input >= 10)
        {
            if (value.Input >= 90)
            {
                value.Output += "XC";
                value.Input -= 90;
            }
            else if (value.Input >= 50)
            {
                value.Output += "L";
                value.Input -= 50;
            }
            else if (value.Input >= 40)
            {
                value.Output += "XL";
                value.Input -= 40;
            }
            else
            {
                value.Output += "X";
                value.Input -= 10;
            }
        }
    }
}


public class RomanHundredExpression : RomanExpression
{
    public override void Interpret(RomanContext value)
    {
        while (value.Input >= 100)
        {
            if (value.Input >= 900)
            {
                value.Output += "CM";
                value.Input -= 900;
            }
            else if (value.Input >= 500)
            {
                value.Output += "D";
                value.Input -= 500;
            }
            else if (value.Input >= 400)
            {
                value.Output += "CD";
                value.Input -= 400;
            }
            else
            {
                value.Output += "C";
                value.Input -= 100;
            }
        }
    }
}

public class RomanThousandExpression : RomanExpression
{
    public override void Interpret(RomanContext value)
    {
        while (value.Input >= 1000)
        {
            value.Output += "M";
            value.Input -= 1000;
        }
    }
}