using System;
using System.Data;
using System.Data.SqlClient;


class Program
{
    static string connectionString = "Data Source=YASIR\\SQLEXPRESS;Initial Catalog=AssignmentFive;Integrated Security=SSPI;";

   

    public static void ReadAllRecords()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Employees";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("_______________________________________________________________________");
                        string showing = $"ID: {reader["ID"]} \n FirstName: {reader["FirstName"]}\n LastName: {reader["LastName"]}\n Email: {reader["Email"]}\n PrimaryPhoneNumber:" +
                            $" {reader["PrimaryPhoneNumber"]} \n SecondaryPhoneNumber: {reader["SecondaryPhoneNumber"]} \n CreatedBy: {reader["CreatedBy"]} \n CreatedOn: {reader["CreatedOn"]}"+
                            $" \n ModifiedBy: {reader["ModifiedBy"]} \n ModifiedOn: {reader["ModifiedOn"]}\n ";
                        Console.WriteLine(showing);
                        Console.WriteLine("_______________________________________________________________________");
                    }
                }
            }
        }
    }

    public static void InsertRecord()
    {
        Console.Write("Enter FirstName: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter LastName: ");
        string lastName = Console.ReadLine();
        Console.Write("Enter Email: ");
        string email = Console.ReadLine();
        Console.Write("Enter PrimaryPhoneNumber: ");
        string primaryPhoneNumber = Console.ReadLine();
        Console.Write("Enter SecondaryPhoneNumber (leave empty if none): ");
        string secondaryPhoneNumber = Console.ReadLine();
        Console.Write("Enter CreatedBy: ");
        string createdBy = Console.ReadLine();
        Console.Write("Enter CreatedOn (YYYY-MM-DD HH:MM:SS): ");
        DateTime createdOn = DateTime.TryParse(Console.ReadLine(), out DateTime parsedDate) ? parsedDate : DateTime.MinValue;

        Console.Write("Enter ModifiedBy (leave empty if none): ");
        string modifiedBy = Console.ReadLine();
        Console.Write("Enter ModifiedON (YYYY-MM-DD HH:MM:SS): ");
        DateTime modifiedOn = DateTime.TryParse(Console.ReadLine(), out DateTime parsedDatee) ? parsedDate : DateTime.MinValue;


        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Employees (FirstName, LastName, Email, PrimaryPhoneNumber, SecondaryPhoneNumber, CreatedBy, CreatedOn,ModifiedBy ,ModifiedOn ) VALUES (@FirstName, @LastName, @Email, @PrimaryPhoneNumber, @SecondaryPhoneNumber, @CreatedBy, @CreatedOn,@ModifiedBy ,@ModifiedOn )";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhoneNumber);
                cmd.Parameters.AddWithValue("@SecondaryPhoneNumber", string.IsNullOrEmpty(secondaryPhoneNumber) ? DBNull.Value : (object)secondaryPhoneNumber);
                cmd.Parameters.AddWithValue("@CreatedBy", createdBy);
                cmd.Parameters.AddWithValue("@CreatedOn", createdOn);
                cmd.Parameters.AddWithValue("@ModifiedBy ", modifiedBy);
                cmd.Parameters.AddWithValue("@ModifiedOn ", modifiedOn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Congrats!!! Record inserted successfully.");
            }
        }
    }

    public static void DeleteRecord(int employeeId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "DELETE FROM Employees WHERE ID = @EmployeeID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine($"Employee with Given ID {employeeId} deleted successfully.");
                else
                    Console.WriteLine($"Employee with Given ID {employeeId} not found.");
            }
        }
    }

    public static void SelectRecordById(int employeeId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Employees WHERE ID = @EmployeeID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine("_______________________________________________________________________");
                        string showing = $"ID: {reader["ID"]} \n FirstName: {reader["FirstName"]}\n LastName: {reader["LastName"]}\n Email: {reader["Email"]}\n PrimaryPhoneNumber:" +
                            $" {reader["PrimaryPhoneNumber"]} \n SecondaryPhoneNumber: {reader["SecondaryPhoneNumber"]} \n CreatedBy: {reader["CreatedBy"]} \n CreatedOn: {reader["CreatedOn"]}" +
                            $" \n ModifiedBy: {reader["ModifiedBy"]} \n ModifiedOn: {reader["ModifiedOn"]}\n ";
                      
                        Console.WriteLine(showing);
                        Console.WriteLine("_______________________________________________________________________");
                    }
                    else
                    {
                        Console.WriteLine($"Employee with ID {employeeId} not found.");
                    }
                }
            }
        }
    }

    public static void UpdateRecord(int employeeId)
    {
        Console.Write("Enter  NEW FirstName: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter  NEW LastName: ");
        string lastName = Console.ReadLine();
        Console.Write("Enter  NEW Email: ");
        string email = Console.ReadLine();
        Console.Write("Enter  NEW PrimaryPhoneNumber: ");
        string primaryPhoneNumber = Console.ReadLine();
        Console.Write("Enter  NEWSecondaryPhoneNumber (leave empty if none): ");
        string secondaryPhoneNumber = Console.ReadLine();
        Console.Write("Enter New CreatedBy: ");
        string createdBy = Console.ReadLine();
        Console.Write("Enter  NEW CreatedOn: ");
        string createdOn = Console.ReadLine();
        Console.Write("Enter  NEW ModifiedBy (leave empty if none): ");
        string modifiedBy = Console.ReadLine();
        Console.Write("Enter  NEW ModifiedOn (leave empty if none): ");
        string modifiedOn = Console.ReadLine();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PrimaryPhoneNumber =" +
                " @PrimaryPhoneNumber, SecondaryPhoneNumber = @SecondaryPhoneNumber,  CreatedBy  = @CreatedBy , CreatedOn = @CreatedOn," +
                " ModifiedBy = @ModifiedBy, ModifiedOn = @ModifiedOn WHERE ID = @EmployeeID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhoneNumber);
                cmd.Parameters.AddWithValue("@SecondaryPhoneNumber", string.IsNullOrEmpty(secondaryPhoneNumber) ? DBNull.Value : (object)secondaryPhoneNumber);
                cmd.Parameters.AddWithValue("@CreatedBy", createdBy);
                cmd.Parameters.AddWithValue("@CreatedOn", createdOn); 
                cmd.Parameters.AddWithValue("@ModifiedBy", string.IsNullOrEmpty(modifiedBy) ? DBNull.Value : (object)modifiedBy);
                cmd.Parameters.AddWithValue("@ModifiedOn", string.IsNullOrEmpty(modifiedOn) ? DBNull.Value : (object)modifiedOn);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine($"Employee with Given ID {employeeId} updated successfully.");
                else
                    Console.WriteLine($"Employee with Given ID {employeeId} not found.");
            }
        }
    }


    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Read All Records");
            Console.WriteLine("2. Insert Record");
            Console.WriteLine("3. Delete Record");
            Console.WriteLine("4. Select Record by ID");
            Console.WriteLine("5. Update Record");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ReadAllRecords();
                    break;
                case 2:
                    InsertRecord();
                    break;
                case 3:
                    Console.Write("Please Enter Employee ID for deletion of Record from Database: ");
                    int deleteId = int.Parse(Console.ReadLine());
                    DeleteRecord(deleteId);
                    break;
                case 4:
                    Console.Write("Enter Employee ID to select from the Database Records: ");
                    int selectId = int.Parse(Console.ReadLine());
                    SelectRecordById(selectId);
                    break;
                case 5:
                    Console.Write("Enter Employee ID to update from the Database Records: ");
                    int updateId = int.Parse(Console.ReadLine());
                    UpdateRecord(updateId);
                    break;
                case 6:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. PLease Try again. for Better choice ");
                    break;
            }
        }
    }
}
