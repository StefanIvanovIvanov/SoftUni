using System;

namespace _01.EventImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Dispatcher dispatcher = new Dispatcher();
            Handler handler = new Handler();
            dispatcher.NameChange += handler.OnDispatcherNameChange;

            var name = Console.ReadLine();

            while (!name.Equals("End"))
            {
                dispatcher.Name = name;
                name = Console.ReadLine();
            }
        }
    }
}
