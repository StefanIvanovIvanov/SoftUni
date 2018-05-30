using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _06.TrafficLights
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            TrafficLight[] trafficLights = new TrafficLight[input.Length];

            for (int i = 0; i < trafficLights.Length; i++)
            {
                trafficLights[i] = (TrafficLight)Activator.CreateInstance(typeof(TrafficLight), new object[] { input[i] });
            }

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                List<string> result = new List<string>();

                foreach (var trafficLight in trafficLights)
                {
                    trafficLight.Update();
                    FieldInfo field = typeof(TrafficLight).GetField("signal", BindingFlags.NonPublic | BindingFlags.Instance);
                    result.Add(field.GetValue(trafficLight).ToString());
                }

                Console.WriteLine(String.Join(" ", result));
            }
        }
    }
}
