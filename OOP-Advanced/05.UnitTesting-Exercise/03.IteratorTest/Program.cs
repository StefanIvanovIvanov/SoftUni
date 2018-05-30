using System;
using System.Linq;
using System.Reflection;

namespace _03.IteratorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputArgs = Console.ReadLine().Split();
            var iterator = new ListIterator(inputArgs.Skip(1));

            MethodInfo[] iteratorMethods = iterator.GetType().GetMethods();

            string command;

            while ((command=Console.ReadLine()) != "END")
            {
                try
                {
                    MethodInfo method = iteratorMethods
                        .FirstOrDefault(m => m.Name == command);

                    if (method == null)
                    {
                        Console.WriteLine($"This option {command} does not exists");
                    }

                    Console.WriteLine(method.Invoke(iterator, new object[] { }));
                }
                catch (TargetInvocationException tie)
                {
                    if (tie.InnerException is InvalidOperationException)
                    {
                        Console.WriteLine(tie.InnerException.Message);
                    }
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
