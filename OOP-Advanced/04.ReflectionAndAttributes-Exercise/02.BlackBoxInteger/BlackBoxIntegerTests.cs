using System.Linq;
using System.Reflection;

namespace P02_BlackBoxInteger
{
    using System;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = Type.GetType("P02_BlackBoxInteger.BlackBoxInteger");
            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            FieldInfo innerValue = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);

            //creates an instance, using the contructor with no parameters
            object instance = Activator.CreateInstance(type, true);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split('_');
                string command = tokens[0];

                MethodInfo method = methods.First(m => m.Name == command);
                int number = int.Parse(tokens[1]);

                //creates a new isntance, using the constructor that requres an int
                method.Invoke(instance, new object[] {number});

                Console.WriteLine(innerValue.GetValue(instance));
            }
        }
    }
}
