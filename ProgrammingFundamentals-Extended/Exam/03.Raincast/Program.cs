using System;
using System.Text.RegularExpressions;

namespace _03.Raincast
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternType = @"^Type: (Normal|Danger|Warning)$";
            string patternSource = @"^Source: ([A-Za-z0-9]+)$";
            string patternForecast = @"^Forecast: ([^\!\.\,\?]+)$";




            string entry = Console.ReadLine();
            while (entry != "Davai Emo")
            {
                bool hasType = false;
                bool hasSource = false;
                bool hasForecast = false;

                Match typeRegex = Regex.Match(entry, patternType);

                if (typeRegex.Success)
                {
                    hasType = true;
                    
                    while (hasType)
                    {
                        string type = typeRegex.Groups[1].Value;

                        entry = Console.ReadLine();
                        
                        Match sourceRegex = Regex.Match(entry, patternSource);
                        if (sourceRegex.Success)
                        {
                            hasSource = true;
                            string source = sourceRegex.Groups[1].Value;

                            while (hasSource)
                            {
                                entry = Console.ReadLine();

                                Match forecastRegex = Regex.Match(entry, patternForecast);
                                if (forecastRegex.Success)
                                {
                                    string forecast = forecastRegex.Groups[1].Value;

                                    Console.WriteLine($"({type}) {forecast} ~ {source}");
                                     hasType = false;
                                     hasSource = false;
                                     hasForecast = false;
                                    break;
                                }
                            }
                        }
                    }              
                }
                entry = Console.ReadLine();
            }
        }
    }
}