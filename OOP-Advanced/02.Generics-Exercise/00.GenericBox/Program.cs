using System;

class Program
{
    static void Main(string[] args)
    {
        var box = new Box<string>(Console.ReadLine());
        Console.WriteLine(box);
    }
}