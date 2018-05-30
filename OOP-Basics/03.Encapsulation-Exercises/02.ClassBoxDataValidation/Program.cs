using System;


class Program
{
    static void Main(string[] args)
    {
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());
        try
        {
            Box box = new Box(length, width, height);
        
        double surfaceArea = 2 * box.Length * box.Width + 2 * box.Length * box.Height + 2 * box.Width * box.Height;
        double lateralSurfaceArea = 2 * box.Length * box.Height + 2 * box.Width * box.Height;
        double volume = box.Length * box.Width * box.Height;

        Console.WriteLine($"Surface Area - {surfaceArea:f2}");
        Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:f2}");
        Console.WriteLine($"Volume - {volume:f2}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        } 
    }
}

