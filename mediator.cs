using System;
using System.Collections.Generic;

// Mediator interface
interface IChatMediator
{
    void SendMessage(User sender, string message);
    void RegisterUser(User user);
}

// Concrete Mediator
class ChatMediator : IChatMediator
{
    private List<User> users = new List<User>();

    public void RegisterUser(User user)
    {
        users.Add(user);
    }

    public void SendMessage(User sender, string message)
    {
        foreach (var user in users)
        {
            if (user != sender)
                user.ReceiveMessage(message);
        }
    }
}

// Colleague
class User
{
    private string name;
    private IChatMediator mediator;

    public User(string name, IChatMediator mediator)
    {
        this.name = name;
        this.mediator = mediator;
        mediator.RegisterUser(this);
    }

    public void SendMessage(string message)
    {
        Console.WriteLine($"{name} sends: {message}");
        mediator.SendMessage(this, message);
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine($"{name} receives: {message}");
    }
}



// Mediator interface
interface IAirTrafficControl
{
    void RegisterFlight(Flight flight);
    void SendMessage(Flight sender, string message);
}

// Concrete Mediator
class AirTrafficControl : IAirTrafficControl
{
    private List<Flight> flights = new List<Flight>();

    public void RegisterFlight(Flight flight)
    {
        flights.Add(flight);
    }

    public void SendMessage(Flight sender, string message)
    {
        foreach (var flight in flights)
        {
            if (flight != sender)
                flight.ReceiveMessage(message);
        }
    }
}

// Colleague
class Flight
{
    private string flightNumber;
    private IAirTrafficControl mediator;

    public Flight(string flightNumber, IAirTrafficControl mediator)
    {
        this.flightNumber = flightNumber;
        this.mediator = mediator;
        mediator.RegisterFlight(this);
    }

    public void SendMessage(string message)
    {
        Console.WriteLine($"{flightNumber} sends: {message}");
        mediator.SendMessage(this, message);
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine($"{flightNumber} receives: {message}");
    }
}




//class Program
//{
//    static void Main()
//    {
//        IChatMediator chatMediator = new ChatMediator();

//        User user1 = new User("Alice", chatMediator);
//        User user2 = new User("Bob", chatMediator);
//        User user3 = new User("Charlie", chatMediator);

//        user1.SendMessage("Hello, everyone!");
//        user2.SendMessage("Hi, Alice!");

//        IAirTrafficControl airTrafficControl = new AirTrafficControl();

//        Flight flight1 = new Flight("ABC123", airTrafficControl);
//        Flight flight2 = new Flight("XYZ789", airTrafficControl);

//        flight1.SendMessage("Requesting landing clearance");
//        flight2.SendMessage("Landing clearance granted");
//    }
//}
