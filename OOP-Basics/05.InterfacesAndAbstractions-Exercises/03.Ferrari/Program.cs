using System;


class Program
{
    static void Main(string[] args)
    {
        string driver = Console.ReadLine();
        IFerrari ferrari = new Ferrari(driver);
        Console.WriteLine(ferrari);
    }
}

