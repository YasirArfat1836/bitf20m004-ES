using System;
using System.Collections;

// Iterator interface
interface IIterator
{
    bool HasNext();
    object Next();
}

// Concrete Iterator
class ConcreteIterator : IIterator
{
    private ArrayList collection;
    private int position = 0;

    public ConcreteIterator(ArrayList collection)
    {
        this.collection = collection;
    }

    public bool HasNext()
    {
        return position < collection.Count;
    }

    public object Next()
    {
        if (HasNext())
        {
            object item = collection[position];
            position++;
            return item;
        }
        else
        {
            return null; // or throw an exception
        }
    }
}

// Aggregate interface
interface IAggregate
{
    IIterator CreateIterator();
}

// Concrete Aggregate
class ConcreteAggregate : IAggregate
{
    private ArrayList collection = new ArrayList();

    public void AddItem(object item)
    {
        collection.Add(item);
    }

    public IIterator CreateIterator()
    {
        return new ConcreteIterator(collection);
    }
}



// Iterator interface
interface IIterator<T>
{
    bool HasNext();
    T Next();
}

// Concrete Iterator
class CustomIterator<T> : IIterator<T>
{
    private CustomCollection<T> collection;
    private int position = 0;

    public CustomIterator(CustomCollection<T> collection)
    {
        this.collection = collection;
    }

    public bool HasNext()
    {
        return position < collection.Count;
    }

    public T Next()
    {
        if (HasNext())
        {
            T item = collection[position];
            position++;
            return item;
        }
        else
        {
            return default(T); // or throw an exception
        }
    }
}

// Aggregate interface
interface IAggregate<T>
{
    IIterator<T> CreateIterator();
}

// Concrete Collection
class CustomCollection<T> : IAggregate<T>
{
    private List<T> collection = new List<T>();

    public void AddItem(T item)
    {
        collection.Add(item);
    }

    public IIterator<T> CreateIterator()
    {
        return new CustomIterator<T>(this);
    }

    public int Count
    {
        get { return collection.Count; }
    }

    public T this[int index]
    {
        get { return collection[index]; }
    }
}

// Client


// Client
//class Program
//{
//    static void Main()
//    {
//        ConcreteAggregate aggregate = new ConcreteAggregate();
//        aggregate.AddItem("Item 1");
//        aggregate.AddItem("Item 2");
//        aggregate.AddItem("Item 3");

//        IIterator iterator = aggregate.CreateIterator();

//        while (iterator.HasNext())
//        {
//            Console.WriteLine(iterator.Next());
//        }

//        CustomCollection<string> customCollection = new CustomCollection<string>();
//        customCollection.AddItem("Item A");
//        customCollection.AddItem("Item B");
//        customCollection.AddItem("Item C");

//        IIterator<string> iterator1 = customCollection.CreateIterator();

//        while (iterator.HasNext())
//        {
//            Console.WriteLine(iterator1.Next());
//        }
//    }
//}
