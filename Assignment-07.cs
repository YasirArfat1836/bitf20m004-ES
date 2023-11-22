using System;
using System.Collections.Generic;

// 1. Adapter Design Pattern
// Example 1
class Target
{
    public virtual void Request()
    {
        Console.WriteLine("Target: The default target behavior.");
    }
}

class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Adaptee: The specific request.");
    }
}

class Adapter : Target
{
    private Adaptee adaptee = new Adaptee();

    public override void Request()
    {
        adaptee.SpecificRequest();
    }
}

// Example 2
class TwoWayAdapter : Target
{
    private Adaptee adaptee = new Adaptee();

    public void SpecificRequest()
    {
        Console.WriteLine("TwoWayAdapter: Adapting Target to Adaptee");
        adaptee.SpecificRequest();
    }

    public override void Request()
    {
        SpecificRequest();
    }
}

// 2. Composite Design Pattern
// Example 1
interface IComponent
{
    void Operation();
}

class Leaf : IComponent
{
    public void Operation()
    {
        Console.WriteLine("Leaf: Performing operation");
    }
}

class Composite : IComponent
{
    private List<IComponent> components = new List<IComponent>();

    public void AddComponent(IComponent component)
    {
        components.Add(component);
    }

    public void Operation()
    {
        foreach (var component in components)
        {
            component.Operation();
        }
    }
}

// Example 2
class AnotherLeaf : IComponent
{
    public void Operation()
    {
        Console.WriteLine("AnotherLeaf: Performing another operation");
    }
}

class AnotherComposite : IComponent
{
    private List<IComponent> components = new List<IComponent>();

    public void AddComponent(IComponent component)
    {
        components.Add(component);
    }

    public void Operation()
    {
        Console.WriteLine("AnotherComposite: Performing another operation");
        foreach (var component in components)
        {
            component.Operation();
        }
    }
}

// 3. Proxy Design Pattern
// Example 1
interface ISubject
{
    void Request();
}

class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("RealSubject: Handling request");
    }
}

class Proxy : ISubject
{
    private RealSubject realSubject = new RealSubject();

    public void Request()
    {
        Console.WriteLine("Proxy: Logging, checking permissions, and forwarding request to RealSubject.");
        realSubject.Request();
    }
}

// Example 2
class AnotherRealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("AnotherRealSubject: Handling request differently");
    }
}

class AnotherProxy : ISubject
{
    private AnotherRealSubject anotherRealSubject = new AnotherRealSubject();

    public void Request()
    {
        Console.WriteLine("AnotherProxy: Logging, checking permissions, and forwarding request to AnotherRealSubject.");
        anotherRealSubject.Request();
    }
}

// 4. Flyweight Design Pattern
// Example 1
class Flyweight
{
    private string sharedState;

    public Flyweight(string sharedState)
    {
        this.sharedState = sharedState;
    }

    public void Operation(string uniqueState)
    {
        Console.WriteLine($"Flyweight: Shared state - {sharedState}, Unique state - {uniqueState}");
    }
}

// Example 2
class AnotherFlyweight
{
    private string sharedState;

    public AnotherFlyweight(string sharedState)
    {
        this.sharedState = sharedState;
    }

    public void Operation(string uniqueState)
    {
        Console.WriteLine($"AnotherFlyweight: Shared state - {sharedState}, Unique state - {uniqueState}");
    }
}

// 5. Facade Design Pattern
// Example 1
class SubsystemA
{
    public void OperationA()
    {
        Console.WriteLine("SubsystemA: Performing operation A");
    }
}

class SubsystemB
{
    public void OperationB()
    {
        Console.WriteLine("SubsystemB: Performing operation B");
    }
}

class Facade
{
    private SubsystemA subsystemA = new SubsystemA();
    private SubsystemB subsystemB = new SubsystemB();

    public void Operation()
    {
        subsystemA.OperationA();
        subsystemB.OperationB();
    }
}

// Example 2
class AnotherSubsystemA
{
    public void AnotherOperationA()
    {
        Console.WriteLine("AnotherSubsystemA: Performing another operation A");
    }
}

class AnotherSubsystemB
{
    public void AnotherOperationB()
    {
        Console.WriteLine("AnotherSubsystemB: Performing another operation B");
    }
}

class AnotherFacade
{
    private AnotherSubsystemA anotherSubsystemA = new AnotherSubsystemA();
    private AnotherSubsystemB anotherSubsystemB = new AnotherSubsystemB();

    public void AnotherOperation()
    {
        anotherSubsystemA.AnotherOperationA();
        anotherSubsystemB.AnotherOperationB();
    }
}

// 6. Bridge Design Pattern
// Example 1
interface IAbstraction
{
    void Operation();
}

class Abstraction : IAbstraction
{
    private IImplementor implementor;

    public Abstraction(IImplementor implementor)
    {
        this.implementor = implementor;
    }

    public void Operation()
    {
        Console.WriteLine("Abstraction: Delegating operation to implementor");
        implementor.Operation();
    }
}

interface IImplementor
{
    void Operation();
}

class ConcreteImplementorA : IImplementor
{
    public void Operation()
    {
        Console.WriteLine("ConcreteImplementorA: Performing operation");
    }
}

class ConcreteImplementorB : IImplementor
{
    public void Operation()
    {
        Console.WriteLine("ConcreteImplementorB: Performing operation");
    }
}

// Example 2
class AnotherAbstraction : IAbstraction
{
    private IImplementor anotherImplementor;

    public AnotherAbstraction(IImplementor anotherImplementor)
    {
        this.anotherImplementor = anotherImplementor;
    }

    public void Operation()
    {
        Console.WriteLine("AnotherAbstraction: Delegating operation to another implementor");
        anotherImplementor.Operation();
    }
}

class AnotherConcreteImplementor : IImplementor
{
    public void Operation()
    {
        Console.WriteLine("AnotherConcreteImplementor: Performing another operation");
    }
}

// 7. Decorator Design Pattern
// Example 1
class ConcreteComponent : IComponent
{
    public void Operation()
    {
        Console.WriteLine("ConcreteComponent: Performing operation");
    }
}

class Decorator : IComponent
{
    private IComponent component;

    public Decorator(IComponent component)
    {
        this.component = component;
    }

    public virtual void Operation()
    {
        component.Operation();
    }
}

class ConcreteDecorator : Decorator
{
    public ConcreteDecorator(IComponent component) : base(component)
    {
    }

    public override void Operation()
    {
        base.Operation();
        Console.WriteLine("ConcreteDecorator: Adding additional behavior");
    }
}

// Example 2
class AnotherConcreteComponent : IComponent
{
    public void Operation()
    {
        Console.WriteLine("AnotherConcreteComponent: Performing another operation");
    }
}

class AnotherDecorator : IComponent
{
    private IComponent anotherComponent;

    public AnotherDecorator(IComponent anotherComponent)
    {
        this.anotherComponent = anotherComponent;
    }

    public void Operation()
    {
        anotherComponent.Operation();
        Console.WriteLine("AnotherDecorator: Adding another additional behavior");
    }
}

class Program
{
    static void Main()
    {
        // 1. Adapter Design Pattern
        Console.WriteLine("Adapter Design Pattern (Example 1):");
        Target target = new Adapter();
        target.Request();

        Console.WriteLine("\nAdapter Design Pattern (Example 2):");
        TwoWayAdapter twoWayAdapter = new TwoWayAdapter();
        twoWayAdapter.Request();

        // 2. Composite Design Pattern
        Console.WriteLine("\nComposite Design Pattern (Example 1):");
        IComponent leaf = new Leaf();
        IComponent composite = new Composite();
        ((Composite)composite).AddComponent(leaf);
        composite.Operation();

        Console.WriteLine("\nComposite Design Pattern (Example 2):");
        IComponent anotherLeaf = new AnotherLeaf();
        IComponent anotherComposite = new AnotherComposite();
        ((AnotherComposite)anotherComposite).AddComponent(anotherLeaf);
        anotherComposite.Operation();

        // 3. Proxy Design Pattern
        Console.WriteLine("\nProxy Design Pattern (Example 1):");
        ISubject proxy = new Proxy();
        proxy.Request();

        Console.WriteLine("\nProxy Design Pattern (Example 2):");
        ISubject anotherProxy = new AnotherProxy();
        anotherProxy.Request();

        // 4. Flyweight Design Pattern
        Console.WriteLine("\nFlyweight Design Pattern (Example 1):");
        Flyweight sharedFlyweight = new Flyweight("SharedState");
        sharedFlyweight.Operation("UniqueState1");
        sharedFlyweight.Operation("UniqueState2");

        Console.WriteLine("\nFlyweight Design Pattern (Example 2):");
        AnotherFlyweight anotherFlyweight = new AnotherFlyweight("AnotherSharedState");
        anotherFlyweight.Operation("AnotherUniqueState1");
        anotherFlyweight.Operation("AnotherUniqueState2");

        // 5. Facade Design Pattern
        Console.WriteLine("\nFacade Design Pattern (Example 1):");
        Facade facade = new Facade();
        facade.Operation();

        Console.WriteLine("\nFacade Design Pattern (Example 2):");
        AnotherFacade anotherFacade = new AnotherFacade();
        anotherFacade.AnotherOperation();

        // 6. Bridge Design Pattern
        Console.WriteLine("\nBridge Design Pattern (Example 1):");
        IImplementor implementorA = new ConcreteImplementorA();
        IAbstraction abstractionA = new Abstraction(implementorA);
        abstractionA.Operation();

        Console.WriteLine("\nBridge Design Pattern (Example 2):");
        IImplementor anotherImplementor = new AnotherConcreteImplementor();
        IAbstraction anotherAbstraction = new AnotherAbstraction(anotherImplementor);
        anotherAbstraction.Operation();

        // 7. Decorator Design Pattern
        Console.WriteLine("\nDecorator Design Pattern (Example 1):");
        IComponent component = new ConcreteComponent();
        Decorator decorator = new ConcreteDecorator(component);
        decorator.Operation();

        Console.WriteLine("\nDecorator Design Pattern (Example 2):");
        IComponent anotherComponent = new AnotherConcreteComponent();
        AnotherDecorator anotherDecorator = new AnotherDecorator(anotherComponent);
        anotherDecorator.Operation();
    }
}
