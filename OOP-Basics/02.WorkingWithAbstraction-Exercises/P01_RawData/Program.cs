using System;
using System.Collections.Generic;
using System.Linq;



class RawData
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = parameters[0];
            Engine engine = new Engine(int.Parse(parameters[1]), int.Parse(parameters[2]));
            Cargo cargo = new Cargo(int.Parse(parameters[3]), parameters[4]);
            List<Tire> tires = new List<Tire>();
            for (int j = 5; j <= 11; j += 2)
            {
                double tirePressure = double.Parse(parameters[j]);
                int tireAge = int.Parse(parameters[j + 1]);
                Tire tire = new Tire(tirePressure, tireAge);
                tires.Add(tire);
            }
            Car car =new Car(model, engine, cargo, tires);
            cars.Add(car);
        }
        
        string command = Console.ReadLine();
        if (command == "fragile")
        {
            List<string> result = Fragile(cars);
            Print(result);
        }
        else
        {
            List<string> result = Flamable(cars);
            Print(result);
        }
    }

    private static List<string> Flamable(List<Car> cars)
    {
        return  cars
            .Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250)
            .Select(x => x.Model)
            .ToList();
    }

    public static List<string> Fragile(List<Car> cars)
    {
        return cars
            .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(t => t.TirePressure < 1))
            .Select(x => x.Model)
            .ToList();
    }

    public static void Print(List<string>result)
    {
        Console.WriteLine(string.Join(Environment.NewLine, result));
    }
}

