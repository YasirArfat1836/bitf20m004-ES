using System;

abstract class Approver
{
    protected Approver successor;

    public void SetSuccessor(Approver successor)
    {
        this.successor = successor;
    }

    public abstract void ProcessRequest(Purchase purchase);
}

class Manager : Approver
{
    public override void ProcessRequest(Purchase purchase)
    {
        if (purchase.Amount <= 1000)
        {
            Console.WriteLine($"Manager approves purchase #{purchase.Number}");
        }
        else if (successor != null)
        {
            successor.ProcessRequest(purchase);
        }
    }
}

class Director : Approver
{
    public override void ProcessRequest(Purchase purchase)
    {
        if (purchase.Amount <= 5000)
        {
            Console.WriteLine($"Director approves purchase #{purchase.Number}");
        }
        else if (successor != null)
        {
            successor.ProcessRequest(purchase);
        }
    }
}

class VicePresident : Approver
{
    public override void ProcessRequest(Purchase purchase)
    {
        if (purchase.Amount <= 10000)
        {
            Console.WriteLine($"Vice President approves purchase #{purchase.Number}");
        }
        else if (successor != null)
        {
            successor.ProcessRequest(purchase);
        }
    }
}

class Purchase
{
    public int Number { get; }
    public double Amount { get; }

    public Purchase(int number, double amount)
    {
        Number = number;
        Amount = amount;
    }
}




abstract class Logger
{
    protected Logger successor;

    public void SetSuccessor(Logger successor)
    {
        this.successor = successor;
    }

    public abstract void LogMessage(string message, LogLevel level);
}

enum LogLevel
{
    Info,
    Warning,
    Error
}

class ConsoleLogger : Logger
{
    public override void LogMessage(string message, LogLevel level)
    {
        if (level == LogLevel.Info)
        {
            Console.WriteLine($"[Console] Info: {message}");
        }
        else if (successor != null)
        {
            successor.LogMessage(message, level);
        }
    }
}

class FileLogger : Logger
{
    public override void LogMessage(string message, LogLevel level)
    {
        if (level == LogLevel.Warning || level == LogLevel.Error)
        {
            Console.WriteLine($"[File] {level}: {message}");
        }
        else if (successor != null)
        {
            successor.LogMessage(message, level);
        }
    }
}

class EmailLogger : Logger
{
    public override void LogMessage(string message, LogLevel level)
    {
        if (level == LogLevel.Error)
        {
            Console.WriteLine($"[Email] Error: {message}");
        }
        else if (successor != null)
        {
            successor.LogMessage(message, level);
        }
    }
}




//class Program
//{
//    static void Main()
//    {
//        Approver manager = new Manager();
//        Approver director = new Director();
//        Approver vp = new VicePresident();

//        manager.SetSuccessor(director);
//        director.SetSuccessor(vp);

//        Purchase purchase1 = new Purchase(1, 800);
//        Purchase purchase2 = new Purchase(2, 3500);
//        Purchase purchase3 = new Purchase(3, 12000);

//        manager.ProcessRequest(purchase1);
//        manager.ProcessRequest(purchase2);
//        manager.ProcessRequest(purchase3);

//        Logger consoleLogger = new ConsoleLogger();
//        Logger fileLogger = new FileLogger();
//        Logger emailLogger = new EmailLogger();

//        consoleLogger.SetSuccessor(fileLogger);
//        fileLogger.SetSuccessor(emailLogger);

//        consoleLogger.LogMessage("This is an informational message.", LogLevel.Info);
//        consoleLogger.LogMessage("This is a warning message.", LogLevel.Warning);
//        consoleLogger.LogMessage("This is an error message.", LogLevel.Error);
//    }
//}
