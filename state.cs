using System;
using System.Threading;

// Context
class TrafficLight
{
    private ITrafficLightState currentState;

    public TrafficLight()
    {
        currentState = new RedState();
    }

    public void SetState(ITrafficLightState state)
    {
        currentState = state;
    }

    public void Request()
    {
        currentState.Handle(this);
    }
}

// State interface
interface ITrafficLightState
{
    void Handle(TrafficLight context);
}

// Concrete States
class RedState : ITrafficLightState
{
    public void Handle(TrafficLight context)
    {
        Console.WriteLine("Red Light - Stop");
        Thread.Sleep(2000); // Simulate time passing
        context.SetState(new GreenState());
    }
}

class GreenState : ITrafficLightState
{
    public void Handle(TrafficLight context)
    {
        Console.WriteLine("Green Light - Go");
        Thread.Sleep(2000); // Simulate time passing
        context.SetState(new YellowState());
    }
}

class YellowState : ITrafficLightState
{
    public void Handle(TrafficLight context)
    {
        Console.WriteLine("Yellow Light - Prepare to Stop");
        Thread.Sleep(2000); // Simulate time passing
        context.SetState(new RedState());
    }
}



// Context
class CeilingFan
{
    private IFanState currentState;

    public CeilingFan()
    {
        currentState = new OffState();
    }

    public void SetState(IFanState state)
    {
        currentState = state;
    }

    public void PullChain()
    {
        currentState.Handle(this);
    }
}

// State interface
interface IFanState
{
    void Handle(CeilingFan context);
}

// Concrete States
class OffState : IFanState
{
    public void Handle(CeilingFan context)
    {
        Console.WriteLine("Turning fan ON (low speed)");
        context.SetState(new LowSpeedState());
    }
}

class LowSpeedState : IFanState
{
    public void Handle(CeilingFan context)
    {
        Console.WriteLine("Increasing fan speed to MEDIUM");
        context.SetState(new MediumSpeedState());
    }
}

class MediumSpeedState : IFanState
{
    public void Handle(CeilingFan context)
    {
        Console.WriteLine("Increasing fan speed to HIGH");
        context.SetState(new HighSpeedState());
    }
}

class HighSpeedState : IFanState
{
    public void Handle(CeilingFan context)
    {
        Console.WriteLine("Turning fan OFF");
        context.SetState(new OffState());
    }
}




//class Program
//{
//    static void Main()
//    {
//        TrafficLight trafficLight = new TrafficLight();

//        for (int i = 0; i < 5; i++)
//        {
//            trafficLight.Request();
//        }

//        CeilingFan ceilingFan = new CeilingFan();

//        for (int i = 0; i < 5; i++)
//        {
//            ceilingFan.PullChain();
//        }
//    }
//}
