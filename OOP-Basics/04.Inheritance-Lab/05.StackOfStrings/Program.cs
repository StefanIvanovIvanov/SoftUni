using System;

public class Program
{
    static void Main(string[] args)
    {
        StackOfStrings stackOfStrings = new StackOfStrings();
        stackOfStrings.Push("item");
        stackOfStrings.Peek();
        stackOfStrings.Pop();
    }
}

