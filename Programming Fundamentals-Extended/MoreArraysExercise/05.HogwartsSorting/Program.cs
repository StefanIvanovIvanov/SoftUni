using System;
using System.Linq;
using System.Text;

namespace _05.HogwartsSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int gryffindor = 0;
            int slytherin = 0;
            int ravenclaw = 0;
            int hufflepuff = 0;
           StringBuilder sb=new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                string[] student = Console.ReadLine().Split(new[]{' '},StringSplitOptions.RemoveEmptyEntries).ToArray();
                foreach (var name in student)
                {
                    sb.Append(name[0]).ToString();
                    for (int j = 0; j < name.Length; j++)
                    {                     
                        sum = sum + name[j];
                    }
                }
                string house = null;
                if (sum % 4 == 0)
                {
                    house = "Gryffindor";
                    gryffindor += 1;
                }
                else if (sum % 4 == 1)
                {
                    house = "Slytherin";
                    slytherin += 1;
                }
                else if (sum % 4 == 2)
                {
                    house = "Ravenclaw";
                    ravenclaw += 1;
                }
                else if (sum % 4 == 3)
                {
                    house = "Hufflepuff";
                    hufflepuff += 1;
                }
               Console.WriteLine($"{house} {sum}{sb}");
                sb.Clear();
                sum = 0;
            }
            Console.WriteLine();
            Console.WriteLine($"Gryffindor: {gryffindor}");
            Console.WriteLine($"Slytherin: {slytherin}");
            Console.WriteLine($"Ravenclaw: {ravenclaw}");
            Console.WriteLine($"Hufflepuff: {hufflepuff}");
        }
    }
}