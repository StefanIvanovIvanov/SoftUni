using System;

public class Program
{
    public static void Main()
    {
        var firstDateAsStr = Console.ReadLine();
        var secondDateAsStr = Console.ReadLine();

        Console.WriteLine(DateModifier.DifferenceInDays(firstDateAsStr, secondDateAsStr));
    }
}