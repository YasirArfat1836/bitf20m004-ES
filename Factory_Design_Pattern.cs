// Product
namespace a2
{
    public interface IVehicle
    {
        void Drive();
    }

    // Concrete Products
    public class Car : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Car is driving.");
        }
    }

    public class Truck : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Truck is driving.");
        }
    }

    // Factory
    public interface IVehicleFactory
    {
        IVehicle CreateVehicle();
    }

    // Concrete Factories
    public class CarFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle()
        {
            return new Car();
        }
    }

    public class TruckFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle()
        {
            return new Truck();
        }
    }

    class Program
    {
        static void Main()
        {
            IVehicleFactory carFactory = new CarFactory();
            IVehicle car = carFactory.CreateVehicle();
            car.Drive(); // Output: Car is driving.

            IVehicleFactory TruckFactory = new TruckFactory();
            IVehicle Truck = TruckFactory.CreateVehicle();
            Truck.Drive(); // Output: Truck is driving.
        }
    }
}