using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            var peopleCount = int.Parse(Console.ReadLine());
            var people =new Dictionary<string, int>(peopleCount);
            for (int counter = 0; counter < peopleCount; counter++)
            {
                var nameAndAge = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);
                people.Add(nameAndAge[0],int.Parse(nameAndAge[1]));
            }
            var condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();
            var filter = CreateFilter(condition, age);
            var printer = CreatePrinter(format);
            
         people.Where(filter).ToList().ForEach(printer);   
        }

        static Func<KeyValuePair<string, int>, bool> CreateFilter(string condition, int age)
        {
            if (condition == "younger")
            {
                return x => x.Value < age;
            }
            else
            {
                return x => x.Value >= age;
            }
        }

        static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return x=>Console.WriteLine(x.Key);
                    break;
                case "age":
                    return x => Console.WriteLine(x.Value);
                    break;
                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");
                    break;
                    default:
                    throw new NotImplementedException();
            }
        }
    }
}
