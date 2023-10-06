using System;

class Program
{
    static void Main()
    {
        
         Task1ConcatenateNames();
        Task2SubstringFetching();
        Task3StringInterpolation();
        Task4ArrayDeclarationAndInitialization();
        Task5aArrayIterationUsingForLoop();
        Task5bArrayIterationUsingForeachLoop();
        Task6SumOfArrayElements();
        Task7FindingMaximumValue();
        Task8ArrayReversal();
        Task9aBoxingAndUnboxingForInteger();
        Task9bBoxingAndUnboxingForDouble();
        Task10aArrayBoxingAndUnboxing();
        Task10bGenericListBoxingAndUnboxing();
        Task11aDynamicVariables();
        Task11bDynamicVariableTypes();
    }

    static void Task1ConcatenateNames()
    {
        // Task 1: String Concatenation
        string firstName, lastName;
        Console.Write("Please Enter your first name: ");
        firstName = Console.ReadLine();
        Console.Write("Please Enter your last name: ");
        lastName = Console.ReadLine();
        Console.WriteLine("Full Name: " + firstName + " " + lastName);
    }

    static void Task2SubstringFetching()
    {

        Console.WriteLine("Enter any sentence i will give you its Last five characters:");
        string sentence=Console.ReadLine();
        if (sentence.Length >= 5)
        {
            string lastFiveChars = sentence.Substring(sentence.Length - 5);
            Console.WriteLine("Last 5 characters: " + lastFiveChars);
        }
        else
        {
            Console.WriteLine("The sentence is too short to fetch the last 5 characters.");
        }
    }


    static void Task3StringInterpolation()
    {
        // Task 3: String Interpolation
        double temperature;
        string city;
        Console.Write("Enter the temperature: ");
        temperature = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the city name: ");
        city = Console.ReadLine();
        Console.WriteLine($"The temperature in {city} is {temperature} degrees Celsius.");
    }

    static void Task4ArrayDeclarationAndInitialization()
    {
        // Task 4: Array Declaration and Initialization
        int[] numbers = new int[] { 1, 2, 3, 4, 5 };
        int i = 1;
        foreach (int num in numbers)
        {
            Console.WriteLine("The "+i+ " Element of the Array " +num);
            i++;
        }
    }

    static void Task5aArrayIterationUsingForLoop()
    {
        // Task 5a: Array Iteration using for loop
        string[] fruits = { "Apple", "Banana", "Orange", "Grapes" };
        for (int fruitIndex = 0; fruitIndex < fruits.Length; fruitIndex++)
        {
            Console.WriteLine(fruits[fruitIndex]);
        }
    }

    static void Task5bArrayIterationUsingForeachLoop()
    {
        // Task 5b: Array Iteration using foreach loop
        string[] colors = { "Red", "Blue", "Green" };
        foreach (string color in colors)
        {
            Console.Write(color + ", ");
        }
        Console.WriteLine();
    }

    static void Task6SumOfArrayElements()
    {
        // Task 6: Sum of Array Elements using do-while loop
        int[] scores = { 85, 92, 78, 95, 88, 76, 89, 91, 87, 93 };
        int sum = 0;
        int index = 0;
        do
        {
            sum += scores[index];
            index++;
        } while (index < scores.Length);
        Console.WriteLine("Sum of scores: " + sum);
    }

    static void Task7FindingMaximumValue()
    {
        // Task 7: Finding the Maximum Value using for loop
        int[] values = { 110, 245, 135, 42, 71 };
        int max = values[0];
        int i = 1;
        while (i < values.Length)
        {
            if (values[i] > max)
            {
                max = values[i];
            }
            i++;
        }
        Console.WriteLine("Maximum value: " + max);
    }

    static void Task8ArrayReversal()
    {
        // Task 8: Array Reversal using foreach loop
        int[] reverseArray = { 1, 2, 3, 4, 5 };
        Array.Reverse(reverseArray);
        foreach (int num in reverseArray)
        {
            Console.WriteLine(num);
        }

    }

    static void Task9aBoxingAndUnboxingForInteger()
    {
        // Task 9a: Boxing and Unboxing for Integer
        int x = 42;
        object boxedX = x;
        int y = (int)boxedX;
        Console.WriteLine("Unboxed value: " + y);
    }

    static void Task9bBoxingAndUnboxingForDouble()
    {
        // Task 9b: Boxing and Unboxing for Double
        double doubleValue = 3.14159;
        object boxedDouble = doubleValue;
        double unboxedValue = (double)boxedDouble;
        Console.WriteLine("Unboxed double value: " + unboxedValue);
    }

    static void Task10aArrayBoxingAndUnboxing()
    {
        // Task 10a: Unboxing from an Array
        int[] numArray = { 2, 4, 6, 8, 10 };
        for (int j = 0; j < numArray.Length; j++)
        {
            object boxedNum = numArray[j];
            int unboxedNum = (int)boxedNum;
            int squaredNum = unboxedNum * unboxedNum;
            Console.WriteLine($"Original: {unboxedNum}, Squared: {squaredNum}");
        }
    }

    static void Task10bGenericListBoxingAndUnboxing()
    {
        // Task 10b: Boxing and Unboxing in a Generic List
        List<object> mixedList = new List<object>();
        mixedList.Add(42);
        mixedList.Add(3.14159);
        mixedList.Add('A');

        foreach (object item in mixedList)
        {
            Console.WriteLine($"Value: {item}, Type: {item.GetType()}");
        }
    }

    static void Task11aDynamicVariables()
    {
        // Task 11a: Dynamic Variables
        dynamic myVariable = 42;
        Console.WriteLine($"Dynamic Variable 1: {myVariable}");
        myVariable = "Hello, Dynamic!";
        Console.WriteLine($"Dynamic Variable 2: {myVariable}");
    }

    static void Task11bDynamicVariableTypes()
    {
        // Task 11b: Dynamic Variable Types
        dynamic myVariable2 = 42;
        Console.WriteLine($"Type of myVariable2: {myVariable2.GetType()}");
        myVariable2 = 3.14;
        Console.WriteLine($"Type of myVariable2: {myVariable2.GetType()}");
        myVariable2 = DateTime.Now;
        Console.WriteLine($"Type of myVariable2: {myVariable2.GetType()}");
        myVariable2 = "Dynamic String";
        Console.WriteLine($"Type of myVariable2: {myVariable2.GetType()}");
    }
}
