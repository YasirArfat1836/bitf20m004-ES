// Abstract Products
namespace a3
{
    public interface IEngine
    {
        void Start();
    }

    public interface IWheels
    {
        void Rotate();
    }

    // Abstract Factory
    public interface IVehicleFactory
    {
        IEngine CreateEngine();
        IWheels CreateWheels();
    }

    // Concrete Products
    public class CarEngine : IEngine
    {
        public void Start()
        {
            Console.WriteLine("Car engine started.");
        }
    }

    public class CarWheels : IWheels
    {
        public void Rotate()
        {
            Console.WriteLine("Car wheels rotating.");
        }
    }

    // Concrete Factory for Car
    public class CarFactory : IVehicleFactory
    {
        public IEngine CreateEngine()
        {
            return new CarEngine();
        }

        public IWheels CreateWheels()
        {
            return new CarWheels();
        }
    }

    class Program
    {
        //static void Main()
        //{
        //    IVehicleFactory carFactory = new CarFactory();
        //    IEngine carEngine = carFactory.CreateEngine();
        //    IWheels carWheels = carFactory.CreateWheels();

        //    carEngine.Start();   // Output: Car engine started.
        //    carWheels.Rotate();  // Output: Car wheels rotating.
        //}
    }
}
