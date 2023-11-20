// Product
namespace a4
{
    public class Computer
    {
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        // ... other properties

        public void DisplayInfo()
        {
            Console.WriteLine($"CPU: {CPU}, RAM: {RAM}, Storage: {Storage}");
        }
    }

    // Builder
    public interface IComputerBuilder
    {
        void BuildCPU();
        void BuildRAM();
        void BuildStorage();
        Computer GetComputer();
    }

    // Concrete Builder
    public class HighPerformanceComputerBuilder : IComputerBuilder
    {
        private Computer computer = new Computer();

        public void BuildCPU()
        {
            computer.CPU = "High-end CPU";
        }

        public void BuildRAM()
        {
            computer.RAM = "16GB RAM";
        }

        public void BuildStorage()
        {
            computer.Storage = "1TB SSD";
        }

        public Computer GetComputer()
        {
            return computer;
        }
    }

    // Director
    public class ComputerDirector
    {
        public void Construct(IComputerBuilder builder)
        {
            builder.BuildCPU();
            builder.BuildRAM();
            builder.BuildStorage();
        }
    }

    class Program
    {
        //static void Main()
        //{
        //    ComputerDirector director = new ComputerDirector();
        //    IComputerBuilder builder = new HighPerformanceComputerBuilder();

        //    director.Construct(builder);
        //    Computer computer = builder.GetComputer();

        //    computer.DisplayInfo(); // Output: CPU: High-end CPU, RAM: 16GB RAM, Storage: 1TB SSD
        //}
    }
}