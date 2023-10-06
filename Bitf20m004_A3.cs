using System;
using System.ComponentModel;
using System.Drawing;

public class Program
{
    static void Main()
    {
        // Greet();
        //Greet("Yasir", "Arfat");
        //double a=CalculateArea();
        //Console.WriteLine("The Area of Rectangle is:"+a);
        //double b=CalculateArea(2.3, 4.5);
        //Console.WriteLine("The Area of Rectangle is:"+b);
        //int sum=AddNumbers(3 , 4 , 7);
        //Console.WriteLine("The Sum:"+sum);
        //int sum1=AddNumbers(4, 3 );
        //Console.WriteLine("The Sum:" + sum1);
        //Book book = new Book("hisotry of programming");
        //Book book1 = new Book("hisotry of programming","yasir arfat");
        //MyList<int> intList = new MyList<int>();
        //MyList<string> stringlist = new MyList<string>();

        //// Add elements to the list
        //intList.Add(101);
        //intList.Add(201);
        //intList.Add(301);

        //intList.Remove(101);

        //stringlist.Add("yasir");
        //stringlist.Add("arfat");
        //stringlist.Add("crickter");

        //// Display the list
        //Console.WriteLine("Integer List:");
        //intList.Display();
        //Console.WriteLine("string List:");
        //stringlist.Display();



        // Test with integers
        //int a = 5, b = 10;
        //Console.WriteLine($"Before swap: a = {a}, b = {b}");
        //Swap(ref a, ref b);
        //Console.WriteLine($"After swap: a = {a}, b = {b}");

        //// Test with strings
        //string str1 = "Yasir", str2 = "Arfat";
        //Console.WriteLine($"\nBefore swap: str1 = \"{str1}\", str2 = \"{str2}\"");
        //Swap(ref str1, ref str2);
        //Console.WriteLine($"After swap: str1 = \"{str1}\", str2 = \"{str2}\"");









        // int[] intArray = { 1, 2, 3, 4, 5 };
        // double[] doubleArray = { 1.1, 2.2, 3.3, 4.4, 5.5 };
        // string[] stringArray = { "apple", "Orange", "Banana" };

        // int intSum = SumElements(intArray);//valid case
        // double doubleSum = SumElements(doubleArray);//valid case
        // //string stringSum= SumElements(stringArray);//not valid case

        // Console.WriteLine($"Sum of integers: {intSum}");
        // Console.WriteLine($"Sum of doubles: {doubleSum}");
        //// Console.WriteLine($"Sum of string: {stringSum}");
        ///



















        StudentDatabase s=new StudentDatabase();

        //menu driven program
        bool exitProgram = false;

        while (!exitProgram)
        {
            Console.WriteLine("Student Database Menu:");
            Console.WriteLine("0. Helper Case 0 for adding records dynamically!!!");
            Console.WriteLine("1. View the student database");
            Console.WriteLine("2. Search for a student by ID");
            Console.WriteLine("3. Update a student's name");
            Console.WriteLine("4. Exit the program");
            Console.Write("Enter your choice (1-4): ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 0:
               
                        s.addRecords(); break;
                    case 1:
                        s.DisplayRecords();
                        break;
                    case 2:
                        s.retrieveRecords();
                        break;
                    case 3:
                        s.UpdateRecords();
                        break;
                    case 4:
                        exitProgram = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
   
    }
    //Optional Arguments
    //a
    static void Greet(string greeting="Hello",string name="World")
    {
        Console.WriteLine(greeting+", "+name+"!");
    }

    //b
    static double CalculateArea(double length=1.0,double width=1.0)
    {
        double area = length * width;
        return area;
    }
    //c
    static int AddNumbers(int n1, int n2,int n3=0)
    {
        return n1 + n2+n3;
    }

    //Generics
    //b
    static void Swap<T>( ref T  a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    //c
    static T SumElements<T>(T[] arr)
    {
        if (!typeof(T).IsPrimitive || !typeof(T).IsValueType)
        {
            throw new ArgumentException("Type T must be a  value  that is compatible with for sum.");
        }

        if (arr.Length == 0)
        {
            throw new ArgumentException("Array cannot be empty.");
        }

        dynamic sum = default(T);

        foreach (T element in arr)
        {
            sum += element;
        }

        return sum;
    }
}


//d
class Book
{
    //public string Title { get; set; }
    //public string Author { get; set; }
    public Book(string title,string author="Unknown")
    {
        //Title= title;
        //Author= author;
        Console.WriteLine("The book has title:"+title+" and "+" Author as "+author);
    }
}


class MyList<T>
{
    private List<T> elements;

    public MyList()
    {
        elements = new List<T>();
    }

    public void Add(T item)
    {
        elements.Add(item);
    }

    public bool Remove(T item)
    {
        return elements.Remove(item);
    }

    public void Display()
    {
        foreach (T element in elements)
        {
            Console.WriteLine(element);
        }
    }
}



class StudentDatabase
{
    Dictionary<int,string> studentRecord = new Dictionary<int,string>();
    //helper function for adding records
    public void addRecords()
    {
        Console.WriteLine("please enter Student id for adding Record:");
        int v = int.Parse(Console.ReadLine());
        Console.WriteLine("please enter Student Name for Adding:");
        string Name = Console.ReadLine();
        studentRecord.Add(v, Name);
    }

    public void retrieveRecords()
    {
        Console.WriteLine("please enter Student id for retrieving Record:");
        int id=int.Parse(Console.ReadLine());
        if(studentRecord.ContainsKey(id))
        {
            string s = studentRecord[id];
            Console.WriteLine(s);
        }
        else
        {
            Console.WriteLine("Student ID not found!!");
        }
    }



    public void DisplayRecords()
    {
       
        foreach (var student in studentRecord)
        {
           
            Console.WriteLine("ID:"+ student.Key);
            Console.WriteLine("Name:"+ student.Value);
        }
       
    }

    public void UpdateRecords()
    {
        Console.WriteLine("please enter Student id for Updating Record:");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("please enter new Student Name:");
        string name = Console.ReadLine();

        if (studentRecord.ContainsKey(id))
        {
            studentRecord[id] = name;
        }
        else
        {
            Console.WriteLine("Student ID not found!!");
        }

         DisplayRecords();
        
    }
}



