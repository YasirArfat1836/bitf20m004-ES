using System;

abstract class CaffeineBeverage
{
    // Template method
    public void PrepareRecipe()
    {
        BoilWater();
        Brew();
        PourInCup();
        AddCondiments();
    }

    // Primitive operations
    protected void BoilWater()
    {
        Console.WriteLine("Boiling water");
    }

    protected void PourInCup()
    {
        Console.WriteLine("Pouring into cup");
    }

    // Abstract methods to be implemented by subclasses
    protected abstract void Brew();
    protected abstract void AddCondiments();
}

class Coffee : CaffeineBeverage
{
    protected override void Brew()
    {
        Console.WriteLine("Brewing coffee grounds");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Adding sugar and milk");
    }
}

class Tea : CaffeineBeverage
{
    protected override void Brew()
    {
        Console.WriteLine("Steeping the tea");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Adding lemon");
    }
}


abstract class Document
{
    // Template method
    public void GenerateDocument()
    {
        AddHeader();
        AddBody();
        AddFooter();
    }

    // Primitive operations
    protected void AddHeader()
    {
        Console.WriteLine("Document Header");
    }

    protected void AddFooter()
    {
        Console.WriteLine("Document Footer");
    }

    // Abstract methods to be implemented by subclasses
    protected abstract void AddBody();
}

class Resume : Document
{
    protected override void AddBody()
    {
        Console.WriteLine("Resume Body");
    }
}

class Letter : Document
{
    protected override void AddBody()
    {
        Console.WriteLine("Letter Body");
    }
}



//class template
//{
//    static void Main()
//    {
//        CaffeineBeverage coffee = new Coffee();
//        CaffeineBeverage tea = new Tea();

//        Console.WriteLine("Making coffee...");
//        coffee.PrepareRecipe();

//        Console.WriteLine("\nMaking tea...");
//        tea.PrepareRecipe();

//        Document resume = new Resume();
//        Document letter = new Letter();

//        Console.WriteLine("Generating Resume...");
//        resume.GenerateDocument();

//        Console.WriteLine("\nGenerating Letter...");
//        letter.GenerateDocument();
//    }
//}
