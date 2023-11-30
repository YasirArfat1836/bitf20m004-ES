using System;
using System.Collections.Generic;

// Subject (Observable)
interface IStock
{
    string Symbol { get; }
    double Price { get; set; }
    void Attach(IInvestor investor);
    void Detach(IInvestor investor);
    void Notify();
}

// Concrete Subject
class Stock : IStock
{
    private readonly List<IInvestor> investors = new List<IInvestor>();

    public string Symbol { get; }
    private double price;

    public double Price
    {
        get { return price; }
        set
        {
            if (price != value)
            {
                price = value;
                Notify();
            }
        }
    }

    public Stock(string symbol, double price)
    {
        Symbol = symbol;
        Price = price;
    }

    public void Attach(IInvestor investor)
    {
        investors.Add(investor);
    }

    public void Detach(IInvestor investor)
    {
        investors.Remove(investor);
    }

    public void Notify()
    {
        foreach (var investor in investors)
        {
            investor.Update(this);
        }
    }
}

// Observer
interface IInvestor
{
    void Update(IStock stock);
}

// Concrete Observer
class Investor : IInvestor
{
    public string Name { get; }

    public Investor(string name)
    {
        Name = name;
    }

    public void Update(IStock stock)
    {
        Console.WriteLine($"Notified {Name} of {stock.Symbol}'s change to {stock.Price}");
    }
}



// Subject (Observable)
interface INewsAgency
{
    void AddSubscriber(INewsSubscriber subscriber);
    void RemoveSubscriber(INewsSubscriber subscriber);
    void NotifySubscribers(string news);
}

// Concrete Subject
class NewsAgency : INewsAgency
{
    private readonly List<INewsSubscriber> subscribers = new List<INewsSubscriber>();

    public void AddSubscriber(INewsSubscriber subscriber)
    {
        subscribers.Add(subscriber);
    }

    public void RemoveSubscriber(INewsSubscriber subscriber)
    {
        subscribers.Remove(subscriber);
    }

    public void NotifySubscribers(string news)
    {
        foreach (var subscriber in subscribers)
        {
            subscriber.Update(news);
        }
    }
}

// Observer
interface INewsSubscriber
{
    void Update(string news);
}

// Concrete Observer
class NewsSubscriber : INewsSubscriber
{
    public string Name { get; }

    public NewsSubscriber(string name)
    {
        Name = name;
    }

    public void Update(string news)
    {
        Console.WriteLine($"{Name} received news: {news}");
    }
}



//class Program
//{
//    static void Main()
//    {
//        Stock stock = new Stock("ABC", 100.0);

//        IInvestor investor1 = new Investor("Investor 1");
//        IInvestor investor2 = new Investor("Investor 2");

//        stock.Attach(investor1);
//        stock.Attach(investor2);

//        stock.Price = 105.0;
//        stock.Price = 98.0;


//        NewsAgency newsAgency = new NewsAgency();

//        INewsSubscriber subscriber1 = new NewsSubscriber("Subscriber 1");
//        INewsSubscriber subscriber2 = new NewsSubscriber("Subscriber 2");

//        newsAgency.AddSubscriber(subscriber1);
//        newsAgency.AddSubscriber(subscriber2);

//        newsAgency.NotifySubscribers("Breaking News: Important event happening!");

//        newsAgency.RemoveSubscriber(subscriber1);

//        newsAgency.NotifySubscribers("Update: Weather forecast for the week");
//    }
//}
