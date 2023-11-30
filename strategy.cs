using System;

// Strategy interface
interface ISortStrategy
{
    void Sort(int[] array);
}

// Concrete Strategies
class BubbleSort : ISortStrategy
{
    public void Sort(int[] array)
    {
        Console.WriteLine("Sorting using Bubble Sort");
        // Implementation of Bubble Sort
    }
}

class QuickSort : ISortStrategy
{
    public void Sort(int[] array)
    {
        Console.WriteLine("Sorting using Quick Sort");
        // Implementation of Quick Sort
    }
}

// Context
class SortContext
{
    private ISortStrategy sortStrategy;

    public SortContext(ISortStrategy strategy)
    {
        this.sortStrategy = strategy;
    }

    public void SetSortStrategy(ISortStrategy strategy)
    {
        this.sortStrategy = strategy;
    }

    public void ExecuteSort(int[] array)
    {
        sortStrategy.Sort(array);
    }
}



// Strategy interface
interface IPaymentProcessor
{
    void ProcessPayment(double amount);
}

// Concrete Strategies
class CreditCardProcessor : IPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing credit card payment of ${amount}");
        // Implementation of credit card payment processing
    }
}

class PayPalProcessor : IPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing PayPal payment of ${amount}");
        // Implementation of PayPal payment processing
    }
}

// Context
class PaymentContext
{
    private IPaymentProcessor paymentProcessor;

    public PaymentContext(IPaymentProcessor processor)
    {
        this.paymentProcessor = processor;
    }

    public void SetPaymentProcessor(IPaymentProcessor processor)
    {
        this.paymentProcessor = processor;
    }

    public void ExecutePayment(double amount)
    {
        paymentProcessor.ProcessPayment(amount);
    }
}




//class Program
//{
//    static void Main()
//    {
//        int[] data = { 7, 2, 5, 1, 9, 0, 3 };

//        SortContext sortContext = new SortContext(new BubbleSort());
//        sortContext.ExecuteSort(data);

//        Console.WriteLine("\nSwitching to Quick Sort\n");

//        sortContext.SetSortStrategy(new QuickSort());
//        sortContext.ExecuteSort(data);

//        PaymentContext paymentContext = new PaymentContext(new CreditCardProcessor());
//        paymentContext.ExecutePayment(100.00);

//        Console.WriteLine("\nSwitching to PayPal\n");

//        paymentContext.SetPaymentProcessor(new PayPalProcessor());
//        paymentContext.ExecutePayment(50.00);
//    }
//}
