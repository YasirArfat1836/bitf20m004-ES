// Prototype
namespace a5
{
    public interface ICloneablePrototype
    {
        ICloneablePrototype Clone();
    }

    // Concrete Prototype
    public class ConcretePrototype : ICloneablePrototype
    {
        public int Value { get; set; }

        public ICloneablePrototype Clone()
        {
            return new ConcretePrototype { Value = this.Value };
        }
    }

    class Program
    {
        //static void Main()
        //{
        //    ConcretePrototype original = new ConcretePrototype { Value = 10 };
        //    ConcretePrototype cloned = (ConcretePrototype)original.Clone();

        //    Console.WriteLine($"Original Value: {original.Value}"); // Output: Original Value: 10
        //    Console.WriteLine($"Cloned Value: {cloned.Value}");     // Output: Cloned Value: 10
        //}
    }
}