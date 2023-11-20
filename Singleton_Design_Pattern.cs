namespace a1
{
    public class Singleton
    {
        private static Singleton instance;

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

        public void PrintMessage()
        {
            Console.WriteLine("Singleton instance is created and used.");
        }
    }

    class Singleton_Design_Pattern
    {
        //static void Main()
        //{
        //    Singleton singleton1 = Singleton.Instance;
        //    singleton1.PrintMessage();

        //    Singleton singleton2 = Singleton.Instance;
        //    singleton2.PrintMessage();

        //    // Both instances point to the same object
        //    Console.WriteLine(singleton1 == singleton2); // Output: True
        //}
    }
}