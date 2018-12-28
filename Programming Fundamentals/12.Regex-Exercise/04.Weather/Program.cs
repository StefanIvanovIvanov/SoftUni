using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"(?<cityName>[A-Z]{2})(?<averageTemperature>\d+\.\d+)(?<weatherType>[A-Za-z]+)(?:\|)";

            var weatherForecast = new Dictionary<string, Dictionary<double, string>>();

            var weatherForecastData = Console.ReadLine();

            while (!weatherForecastData.Equals("end"))
            {
                var match = Regex.Match(weatherForecastData, pattern);

                if (match.Success)
                {
                    var cityName = match.Groups["cityName"].Value;
                    var averageTemperature = double.Parse(match.Groups["averageTemperature"].Value);
                    var weatherType = match.Groups["weatherType"].Value;

                    if (!weatherForecast.ContainsKey(cityName))
                    {
                        weatherForecast[cityName] = new Dictionary<double, string>();
                        weatherForecast[cityName].Add(averageTemperature, weatherType);
                    }

                    else
                    {
                        weatherForecast[cityName].Clear();
                        weatherForecast[cityName].Add(averageTemperature, weatherType);
                    }
                }

                weatherForecastData = Console.ReadLine();
            }

            weatherForecast = weatherForecast
                .OrderBy(x => x.Value.Keys.First())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var city in weatherForecast)
            {
                var cityName = city.Key;
                var weathers = city.Value;

                foreach (var weather in weathers)
                {
                    var averageTemperature = weather.Key;
                    var weatherType = weather.Value;

                    Console.WriteLine($"{cityName} => {averageTemperature:F2} => {weatherType}");
                }
            }
        }
    }
}