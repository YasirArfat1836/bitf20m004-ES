using System;
using System.Data.Common;
using VehicleNamespace;
using LocationNamespace;
using PassengerNamespace;
using DriverNamespace;
using RideNamespace;
using AdminNamespace;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using System.Diagnostics;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Collections;
using System.Linq;

namespace DriverNamespace
{
    public class Driver
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Location CurrentLocation { get; set; }
        public Vehicle Vehicle { get; set; }
        public List<int> Ratings { get; set; } = new List<int>();
        public bool Availability { get;  set; }

     

        public bool updateAvailability()
        {
            
            Console.WriteLine("Select availability (1 for Available, 2 for Unavailable):");
            int availabilityChoice = Convert.ToInt32(Console.ReadLine());

            if (availabilityChoice == 1)
            {
                Availability = true;
                Console.WriteLine("Availability set to Available.");
            }
            else if (availabilityChoice == 2)
            {
                Availability = false;
                Console.WriteLine("Availability set to Unavailable.");
            }
            else
            {
                Console.WriteLine("Invalid choice for availability.");
            }
            return Availability;
        }

        public double getRating()
        {
            if (Ratings.Count > 0)
            {
                double averageRating = Ratings.Average();
                return averageRating;
            }
            else
            {
               
                return 0.0; 
            }

        }


        public void updateLocation()
        {
            Console.WriteLine("Enter New Location:");
            string newLocation = Console.ReadLine();
            string[] newLocationParts = newLocation.Split(',');
            CurrentLocation.latitude = float.Parse(newLocationParts[0]);
            CurrentLocation.longitude = float.Parse(newLocationParts[1]);
            Console.WriteLine("Location updated.");
        }



    }
}




namespace PassengerNamespace
{
    public class Passenger
    {
        Driver driver=new Driver();
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        //Ride newride= new Ride();
        //Location Slocation = new Location();
        //Location Elocation = new Location();

        public string bookRide()
        {
            //Passenger passenger = new Passenger();
            Console.WriteLine("Enter Name:");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Phone no:");
            PhoneNumber = Console.ReadLine();

            Vehicle vehicle = new Vehicle();
            Console.WriteLine("Enter Ride Type:");
            string v=vehicle.Type = Console.ReadLine();
            return v;


            
           

    }

        public void giveRating()
        {
            Console.WriteLine("Happy Travel…! \r\n Give rating out of 5:");
            int rating = int.Parse(Console.ReadLine());
            if (rating<1 &&rating>5)
            {
                Console.WriteLine("invalid rating ,please give rating from 1 to 5");
            }
            else
            { 
                
                driver.Ratings.Add(rating);

            }
        }



    }

}

namespace RideNamespace
{
    public class Ride
    {
        
        Location Slocation = new Location();
        Location Elocation = new Location();
        public Location start_location { get; set; }
        public Location end_location { get; set; }
        public int price { get; set; }
        public Driver driver { get; set; }
        public Passenger passenger { get; set; }


        public void assignPassenger(Passenger p)

        {
            Passenger pass = new Passenger();
            pass = p;
            passenger = pass;


        }
        public void assignDriver(Driver driver)
        {
            Driver closestDriver = null;
            double minDistance = double.MaxValue;

            // Check if the provided driver is available and not null
            if (driver != null && driver.Availability)
            {
                // Iterate through available drivers (in this case, we're only checking the provided driver)
                double distance = CalculateDistance(start_location, driver.CurrentLocation);

                // Calculate the Euclidean distance between driver's location and passenger's starting location
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestDriver = driver;
                }
            }

            // Check if a closest available driver was found
            if (closestDriver != null)
            {
                // Assign the closest available driver to the ride
                driver = closestDriver;
                Console.WriteLine($"Assigned driver: {driver.Name}");
            }
            else
            {
                Console.WriteLine("No available drivers found.");
            }
        }


        public void getLocations()
        {
            Console.WriteLine("Enter Start Location:");
            string startingLocation = Console.ReadLine();
            string[] StartingLocationParts = startingLocation.Split(',');
            Slocation.latitude = float.Parse(StartingLocationParts[0]);
            Slocation.longitude = float.Parse(StartingLocationParts[1]);
            start_location = Slocation;

            Console.WriteLine("Enter End Location:");
            string EndingLocation = Console.ReadLine();
            string[] EndingLocationParts = EndingLocation.Split(',');
            Elocation.latitude = float.Parse(EndingLocationParts[0]);
            Elocation.longitude = float.Parse(EndingLocationParts[1]);
            end_location = Elocation;
        }

        public void CalculatePrice( string v)
        {
            double distance = CalculateDistance(start_location, end_location);

            float fuelPrice = 0.0f;
            float fuelConsumption = 0.0f; // Changed from fuelAverage
            float commissionPercentage = 0.0f;

            switch (v.ToLower())
            {
                case "bike":
                    fuelPrice = 300.0f;
                    fuelConsumption = 50.0f; 
                    commissionPercentage = 0.05f;
                    break;
                case "rickshaw":
                    fuelPrice = 300.0f;
                    fuelConsumption = 35.0f;
                    commissionPercentage = 0.10f;
                    break;
                case "car":
                    fuelPrice = 300.0f;
                    fuelConsumption = 15.0f; 
                    commissionPercentage = 0.20f;
                    break;
                default:
                    Console.WriteLine("Invalid ride type.");
                    break;
            }

           
            float fuelUsed = (float)(distance / fuelConsumption);
            float commission = fuelUsed * fuelPrice * commissionPercentage;
            float price = fuelUsed * fuelPrice + commission;
            int totalPrice = Convert.ToInt32(price);
            Console.WriteLine("-------------THANK YOU----------------");
            Console.WriteLine($"Price for the Ride is: {totalPrice}");
            
        }



        private double CalculateDistance(Location location1, Location location2)
        {
            double deltaX = location2.latitude - location1.latitude;
            double deltaY = location2.longitude - location1.longitude;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        
    }

}



namespace VehicleNamespace
{
    public class Vehicle
    {
        public string Type { get; set; }
        public string model { get; set; }
        public string license_plate { get; set; }



    }

}


namespace LocationNamespace
{
    public class Location
    {
        public float latitude { get; set; }
        public float longitude { get; set; }


        public void setLocation(float latitude,float longitude)
        {

        }

    }

}


namespace AdminNamespace

{
    public class Admin
    {
        public Dictionary<int, Driver> driverLists { get; set; } = new Dictionary<int, Driver>();


        public void AddDriver()
        {
            Console.WriteLine("\nAdd Driver:");

            int id;
            do
            {
                Console.Write("Enter Driver ID: ");
            } while (!int.TryParse(Console.ReadLine(), out id) || id <= 0);

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid input!! Please enter a non-empty name :)");
                Console.Write("Enter Name: ");
                name = Console.ReadLine();
            }

            int age;
            do
            {
                Console.Write("Enter Age: ");
            } while (!int.TryParse(Console.ReadLine(), out age) || age < 18 || age > 70);

            Console.Write("Enter Gender: ");
            string gender = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(gender) || (gender.ToLower() != "male" && gender.ToLower() != "female"))
            {
                Console.WriteLine("Invalid input!! Please enter 'Male' or 'Female' for gender :)");
                Console.Write("Enter Gender: ");
                gender = Console.ReadLine();
            }

            Console.Write("Enter Address: ");
            string address = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("Invalid input!! Please enter a non-empty address :)");
                Console.Write("Enter Address: ");
                address = Console.ReadLine();
            }

            Console.Write("Enter Vehicle Type (Car, Bike, Rickshaw): ");
            string vehicleType = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(vehicleType))
            {
                Console.WriteLine("Invalid input!! Please enter a valid vehicle type (Car, Bike, Rickshaw) :) ");
                Console.Write("Enter Vehicle Type: ");
                vehicleType = Console.ReadLine();
            }

            Console.Write("Enter Vehicle Model: ");
            string vehicleModel = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(vehicleModel))
            {
                Console.WriteLine("Invalid input!! Please enter a non-empty vehicle model :)");
                Console.Write("Enter Vehicle Model: ");
                vehicleModel = Console.ReadLine();
            }

            Console.Write("Enter Vehicle License Plate: ");
            string licensePlate = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(licensePlate))
            {
                Console.WriteLine("Invalid input!! Please enter a non-empty license plate :)");
                Console.Write("Enter Vehicle License Plate: ");
                licensePlate = Console.ReadLine();
            }

            Driver newDriver = new Driver
            {

                Name = name,
                Age = age,
                Gender = gender,
                Address = address,
                Vehicle = new Vehicle { Type = vehicleType, model = vehicleModel, license_plate = licensePlate }
            };

            driverLists.Add(id, newDriver);
            Console.WriteLine("Driver added successfully.");
        }

        public void RemoveDriver()
        {
            Console.Write("Enter Driver ID to remove :");
            int id;
            Console.ForegroundColor = ConsoleColor.Green;
            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Invalid input!! Please enter a valid driver ID :)");
                Console.Write("Enter Driver ID to remove: ");
                Console.ForegroundColor = ConsoleColor.Green;
            }



            if (driverLists.ContainsKey(id))
            {
                driverLists.Remove(id);
                Console.WriteLine("Removed Successfully!!");
            }
            else
            {
                Console.WriteLine("Driver with the specified ID does not exist in the Driver List!!!");
            }

        }

        public void UpdateDriver()
        {
            Console.WriteLine("Enter Driver ID to update: ");
            int driverIdToUpdate = int.Parse(Console.ReadLine());

            // Check if the driver with the given ID exists in the dictionary
            if (driverLists.TryGetValue(driverIdToUpdate, out Driver driverToUpdate))
            {
                Console.WriteLine($"-------------Driver with ID {driverIdToUpdate} exists-------------");

                Console.WriteLine("Enter Name (or leave empty to skip): ");
                string updatedName = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedName))
                {
                    driverToUpdate.Name = updatedName;
                }

                Console.WriteLine("Enter Age (or leave empty to skip): ");
                string ageInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(ageInput) && int.TryParse(ageInput, out int updatedAge))
                {
                    driverToUpdate.Age = updatedAge;
                }

                Console.WriteLine("Enter Gender (or leave empty to skip): ");
                string updatedGender = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedGender))
                {
                    driverToUpdate.Gender = updatedGender;
                }

                Console.WriteLine("Enter Address (or leave empty to skip): ");
                string updatedAddress = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedAddress))
                {
                    driverToUpdate.Address = updatedAddress;
                }

                Console.WriteLine("Enter Vehicle Type (or leave empty to skip): ");
                string updatedVehicleType = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedVehicleType))
                {
                    driverToUpdate.Vehicle.Type = updatedVehicleType;
                }

                Console.WriteLine("Enter Vehicle Model (or leave empty to skip): ");
                string updatedVehicleModel = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedVehicleModel))
                {
                    driverToUpdate.Vehicle.model = updatedVehicleModel;
                }

                Console.WriteLine("Enter Vehicle License Plate (or leave empty to skip): ");
                string updatedLicensePlate = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedLicensePlate))
                {
                    driverToUpdate.Vehicle.license_plate = updatedLicensePlate;
                }

                Console.WriteLine("Driver information updated successfully!");
            }
            else
            {
                Console.WriteLine($"Driver with ID {driverIdToUpdate} not found.");
            }
        }

        public void SearchDriver()
        {
            Console.WriteLine("Enter Driver ID (leave empty to skip): ");
            int searchId = int.TryParse(Console.ReadLine(), out int id) ? id : 0;

            Console.WriteLine("Enter Name (leave empty to skip): ");
            string searchName = Console.ReadLine();

            Console.WriteLine("Enter Age (leave empty to skip): ");
            int searchAge = int.TryParse(Console.ReadLine(), out int age) ? age : 0;

            Console.WriteLine("Enter Gender (leave empty to skip): ");
            string searchGender = Console.ReadLine();

            Console.WriteLine("Enter Address (leave empty to skip): ");
            string searchAddress = Console.ReadLine();

            Console.WriteLine("Enter Vehicle Type (leave empty to skip): ");
            string searchVehicleType = Console.ReadLine();

            Console.WriteLine("Enter Vehicle Model (leave empty to skip): ");
            string searchVehicleModel = Console.ReadLine();

            Console.WriteLine("Enter Vehicle License Plate (leave empty to skip): ");
            string searchLicensePlate = Console.ReadLine();

            if (driverLists.ContainsKey(searchId))
            {
                Driver driver = driverLists[searchId];

                string output = "---------------------------------------------------------------------\n";
                output += "Name   Age   Gender  Address  V.Type   V.Model   V.License\n";
                output += "---------------------------------------------------------------------\n";

                if (!string.IsNullOrEmpty(searchName))
                {
                    output += $"{driver.Name}   ";
                }
                if (searchAge != 0)
                {
                    output += $"{driver.Age}   ";
                }
                if (!string.IsNullOrEmpty(searchGender))
                {
                    output += $"{driver.Gender}   ";
                }
                if (!string.IsNullOrEmpty(searchAddress))
                {
                    output += $"{driver.Address}   ";
                }
                if (!string.IsNullOrEmpty(searchVehicleType))
                {
                    output += $"{searchVehicleType}   ";
                }
                if (!string.IsNullOrEmpty(searchVehicleModel))
                {
                    output += $"{searchVehicleModel}   ";
                }
                if (!string.IsNullOrEmpty(searchLicensePlate))
                {
                    output += $"{searchLicensePlate}   ";
                }

                Console.WriteLine(output.Trim()); // Trim to remove trailing spaces
            }
            else
            {

                Console.WriteLine("Driver not found");
            }
        }
        public bool searchonlyDriver(int id, string name)
        {
            if (driverLists.ContainsKey(id))
            {
                Driver driver = driverLists[id];
                if (driver.Name == name)
                {

                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }


    }








    namespace MainNamespace
    {
        class Program

        {

            public static void Main()
            {
                Admin admin = new Admin();
                Passenger passenger = new Passenger();
                Driver driver = new Driver();
                Ride newride= new Ride();
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("----------------------------------------------------------------------------------\n");
                    Console.WriteLine("WELCOME TO MYRIDE");
                    Console.WriteLine("----------------------------------------------------------------------------------");

                    Console.WriteLine("1. Book a Ride");
                    Console.WriteLine("2. Enter as Driver");
                    Console.WriteLine("3. Enter as Admin");

                    Console.WriteLine("Press 1 to 3 to select an option");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        Console.WriteLine("Book a Ride");
                        string type=passenger.bookRide();
                        newride.getLocations();
                        newride.CalculatePrice(type);
                        newride.assignDriver(newride.driver);
                        newride.assignPassenger(newride.passenger);
                        
                        Console.WriteLine("Enter ‘Y’ if you want to Book the ride, enter ‘N’ if you want to cancel operation: ");
                        char choose = char.Parse(Console.ReadLine());
                        if (choose == 'y' || choose == 'Y')
                        {
                            passenger.giveRating();
                            break;
                        }
                    }
                    else if (choice == 2)
                    {
                        bool r = false;
                        while (!r)
                        {
                            Console.WriteLine("Enter as Driver");
                            Console.WriteLine("Enter ID:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Name:");
                            string Name = Console.ReadLine();
                            bool exists = admin.searchonlyDriver(id, Name);

                            if (exists)
                            {
                                Console.WriteLine("Hello " + Name);
                                Console.WriteLine("Enter Current Location:");
                                string CLocation = Console.ReadLine();
                                string[] CLocationParts = CLocation.Split(',');
                                driver.CurrentLocation = new Location
                                {
                                    latitude = float.Parse(CLocationParts[0]),
                                    longitude = float.Parse(CLocationParts[1])
                                };

                                Console.WriteLine("Current Location Collected!!!");

                                bool isfalse = false;

                                while (!isfalse)
                                {
                                    Console.WriteLine("1. Change Availability");
                                    Console.WriteLine("2. Change Location");
                                    Console.WriteLine("3. Exit as Driver");

                                    Console.WriteLine("Enter your choice:");

                                    int option = Convert.ToInt32(Console.ReadLine());

                                    if (option == 1)
                                    {
                                        //change availability
                                        driver.updateAvailability();
                                    }
                                    else if (option == 2)
                                    {
                                        // Change Location
                                        driver.updateLocation();
                                    }
                                    else if (option == 3)
                                    {
                                        // Exit as Driver
                                        isfalse = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid choice. Please select a valid option.");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("The driver does not Exist");
                                break; // Go back to the main menu for "myride"
                            }
                        }
                    }
                    else if (choice == 3)
                    {
                        bool backToMainMenu = false;
                        while (!backToMainMenu)
                        {
                            Console.WriteLine("Enter as Admin");
                            Console.WriteLine("1. Add Driver");
                            Console.WriteLine("2. Remove Driver");
                            Console.WriteLine("3. Update Driver");
                            Console.WriteLine("4. Search Driver");
                            Console.WriteLine("5. Exit as Admin");
                            Console.WriteLine("Press 1 to 5 to select an option");
                            int choose1 = Convert.ToInt32(Console.ReadLine());
                            if (choose1 == 1)
                            {
                                admin.AddDriver();
                            }
                            else if (choose1 == 2)
                            {
                                admin.RemoveDriver();
                            }
                            else if (choose1 == 3)
                            {
                                admin.UpdateDriver();
                            }
                            else if (choose1 == 4)
                            {
                                admin.SearchDriver();
                            }
                            else if (choose1 == 5)
                            {
                                backToMainMenu = true;
                            }
                        }
                    }
                }
            }

        }
    }
}

