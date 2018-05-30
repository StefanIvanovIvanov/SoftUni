using System;


public class Program
{
    public static void Main()
    {
        string[] carArgs = Console.ReadLine().Split();
        string[] truckArgs = Console.ReadLine().Split();
        Vehicle car = new Car(double.Parse(carArgs[1]), double.Parse(carArgs[2]));
        Vehicle truck = new Truck(double.Parse(truckArgs[1]), double.Parse(truckArgs[2]));

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] args = Console.ReadLine().Split();

            try
            {
                ParseCommands(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



        void ParseCommands(string[] args)
        {
            string command = args[0];
            string typeOfVehicle = args[1];
            double fuelOrDistance = double.Parse(args[2]);

            if (typeOfVehicle == "Car")
            {
                if (command == "Drive")
                {
                    car.Drive(fuelOrDistance);
                }
                else
                {
                    car.Refuel(fuelOrDistance);
                }
            }
            else if (typeOfVehicle == "Truck")
            {
                if (command == "Drive")
                {
                    truck.Drive(fuelOrDistance);
                }
                else
                {
                    truck.Refuel(fuelOrDistance);
                }
            }
        }
        Console.WriteLine(car);
        Console.WriteLine(truck);
    }
}

