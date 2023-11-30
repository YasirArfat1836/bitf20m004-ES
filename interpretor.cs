using System;

// Context
class Context
{
    public string Input { get; set; }
    public int RomanOutput { get; set; }
    public bool BooleanOutput { get; set; }
}

// Abstract Expression
interface IExpression
{
    void Interpret(Context context);
}

// Terminal Expression for Roman Numerals
class TerminalRomanExpression : IExpression
{
    public void Interpret(Context context)
    {
        if (context.Input.StartsWith("IV"))
        {
            context.RomanOutput += 4;
            context.Input = context.Input.Substring(2);
        }
        else if (context.Input.StartsWith("IX"))
        {
            context.RomanOutput += 9;
            context.Input = context.Input.Substring(2);
        }
        else if (context.Input.StartsWith("XL"))
        {
            context.RomanOutput += 40;
            context.Input = context.Input.Substring(2);
        }
        else if (context.Input.StartsWith("XC"))
        {
            context.RomanOutput += 90;
            context.Input = context.Input.Substring(2);
        }
        else if (context.Input.StartsWith("CD"))
        {
            context.RomanOutput += 400;
            context.Input = context.Input.Substring(2);
        }
        else if (context.Input.StartsWith("CM"))
        {
            context.RomanOutput += 900;
            context.Input = context.Input.Substring(2);
        }
        else if (context.Input.StartsWith("I"))
        {
            context.RomanOutput += 1;
            context.Input = context.Input.Substring(1);
        }
        else if (context.Input.StartsWith("V"))
        {
            context.RomanOutput += 5;
            context.Input = context.Input.Substring(1);
        }
        else if (context.Input.StartsWith("X"))
        {
            context.RomanOutput += 10;
            context.Input = context.Input.Substring(1);
        }
        else if (context.Input.StartsWith("L"))
        {
            context.RomanOutput += 50;
            context.Input = context.Input.Substring(1);
        }
        else if (context.Input.StartsWith("C"))
        {
            context.RomanOutput += 100;
            context.Input = context.Input.Substring(1);
        }
        else if (context.Input.StartsWith("D"))
        {
            context.RomanOutput += 500;
            context.Input = context.Input.Substring(1);
        }
        else if (context.Input.StartsWith("M"))
        {
            context.RomanOutput += 1000;
            context.Input = context.Input.Substring(1);
        }
    }
}

// Terminal Expression for Boolean Expressions
class TerminalBooleanExpression : IExpression
{
    private string variable;

    public TerminalBooleanExpression(string variable)
    {
        this.variable = variable;
    }

    public void Interpret(Context context)
    {
        if (context.Input.Contains(variable))
        {
            context.BooleanOutput = true;
        }
        else
        {
            context.BooleanOutput = false;
        }
    }
}

// Non-terminal Expression
class NonTerminalExpression : IExpression
{
    public List<IExpression> Expressions { get; } = new List<IExpression>();

    public void Interpret(Context context)
    {
        foreach (var expression in Expressions)
        {
            expression.Interpret(context);
        }
    }
}

// Non-terminal Expression
class AndExpression : IExpression
{
    private IExpression expression1;
    private IExpression expression2;

    public AndExpression(IExpression expression1, IExpression expression2)
    {
        this.expression1 = expression1;
        this.expression2 = expression2;
    }

    public void Interpret(Context context)
    {
        expression1.Interpret(context);
        bool result1 = context.BooleanOutput;

        expression2.Interpret(context);
        bool result2 = context.BooleanOutput;

        context.BooleanOutput = result1 && result2;
    }
}

// Non-terminal Expression
class OrExpression : IExpression
{
    private IExpression expression1;
    private IExpression expression2;

    public OrExpression(IExpression expression1, IExpression expression2)
    {
        this.expression1 = expression1;
        this.expression2 = expression2;
    }

    public void Interpret(Context context)
    {
        expression1.Interpret(context);
        bool result1 = context.BooleanOutput;

        expression2.Interpret(context);
        bool result2 = context.BooleanOutput;

        context.BooleanOutput = result1 || result2;
    }
}

// Client
//class Program
//{
//    static void Main()
//    {
//        string roman = "MCMIV"; // 1904 in Roman numerals
//        Context romanContext = new Context { Input = roman };
//        NonTerminalExpression romanExpression = new NonTerminalExpression();
//        romanExpression.Expressions.Add(new TerminalRomanExpression());
//        romanExpression.Interpret(romanContext);
//        Console.WriteLine($"{roman} in Roman numerals is {romanContext.RomanOutput}");

//        string booleanInput = "A AND (B OR C)";
//        Context booleanContext = new Context { Input = booleanInput };
//        NonTerminalExpression booleanExpression = new NonTerminalExpression();
//        booleanExpression.Expressions.Add(new TerminalBooleanExpression("A"));
//        booleanExpression.Expressions.Add(new AndExpression(
//            new TerminalBooleanExpression("B"),
//            new OrExpression(
//    new TerminalBooleanExpression("B"),
//    new TerminalBooleanExpression("C")
//)
//        ));
//        booleanExpression.Interpret(booleanContext);
//        Console.WriteLine($"{booleanInput} is {booleanContext.BooleanOutput}");
//    }
//}
