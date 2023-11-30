using System;
using System.Collections.Generic;

namespace MementoExample
{
    // Memento
    class Memento
    {
        public string State { get; private set; }

        public Memento(string state)
        {
            State = state;
        }
    }

    // Originator
    class Originator
    {
        private string state;
        private Stack<Memento> history = new Stack<Memento>();

        public string State
        {
            get { return state; }
            set
            {
                Console.WriteLine($"Setting state to: {value}");
                state = value;
                SaveState();
            }
        }

        public Memento SaveState()
        {
            Console.WriteLine("Saving state");
            Memento memento = new Memento(state);
            history.Push(memento);
            return memento;
        }

        public void RestoreState()
        {
            if (history.Count > 0)
            {
                Memento memento = history.Pop();
                Console.WriteLine($"Restoring state to: {memento.State}");
                state = memento.State;
            }
            else
            {
                Console.WriteLine("No more states to restore");
            }
        }
    }

    // Caretaker
    class Caretaker
    {
        public Memento Memento { get; set; }
        public Stack<Memento> History { get; } = new Stack<Memento>();
    }

    // Client
    class Program
    {
        static void Main()
        {
            // Example 1
            Originator originator1 = new Originator();
            Caretaker caretaker1 = new Caretaker();

            originator1.State = "State 1";
            caretaker1.Memento = originator1.SaveState();

            originator1.State = "State 2";
            Console.WriteLine($"Current state: {originator1.State}");

            originator1.RestoreState();
            Console.WriteLine($"Restored state: {originator1.State}");

            // Example 2
            Originator originator2 = new Originator();
            Caretaker caretaker2 = new Caretaker();

            originator2.State = "State 1";
            caretaker2.History.Push(originator2.SaveState());

            originator2.State = "State 2";
            caretaker2.History.Push(originator2.SaveState());

            Console.WriteLine($"Current state: {originator2.State}");

            originator2.RestoreState();
            Console.WriteLine($"Restored state: {originator2.State}");

            originator2.RestoreState();
            Console.WriteLine($"Restored state: {originator2.State}");
        }
    }
}
