using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.HornetComm
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> broadcasts=new List<string>();
            List<string> messages = new List<string>();

            string messagePattern = @"^([0-9]+) <-> ([A-Za-z0-9]+$)";

            string broadcastPattern = @"^([^0-9]+) <-> ([A-Za-z0-9]+)$";


            while (input != "Hornet is Green")
            {              
                //message
                Match messageMatch = Regex.Match(input, messagePattern);            

                if (messageMatch.Success)
                {
                    string firstQuerry = messageMatch.Groups[1].Value;
                    string secondQuerry = messageMatch.Groups[2].Value;

                    char[] reverse = firstQuerry.ToCharArray().Reverse().ToArray();
                    string newMessage = string.Join("", reverse);

                    string addMeesage = $"{newMessage} -> {secondQuerry}";
                    messages.Add(addMeesage);
                }

                //broadcast
                Match broadcastMatch = Regex.Match(input, broadcastPattern);

                if (broadcastMatch.Success)
                {
                    string firstQuerry = broadcastMatch.Groups[1].Value;
                    string secondQuerry = broadcastMatch.Groups[2].Value;
                    char[] charArr = secondQuerry.ToCharArray();

                    for (int i = 0; i < charArr.Length; i++)
                    {
                        if (char.IsLower(charArr[i]))
                        {
                            charArr[i] = char.ToUpper(charArr[i]);
                        }
                        else if (char.IsUpper(charArr[i]))
                        {
                            charArr[i] = char.ToLower(charArr[i]);
                        }
                    }
                    string newFreq=String.Join("",charArr);
                    string toAdd = $"{newFreq} -> {firstQuerry}";
                    broadcasts.Add(toAdd);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Broadcasts:");
            if (broadcasts.Count > 0)
            {                         
                Console.WriteLine(string.Join(Environment.NewLine, broadcasts));
            }
            else
            {
                Console.WriteLine("None");
            }
            Console.WriteLine("Messages:");
            if (messages.Count > 0)
            {                
                Console.WriteLine(string.Join(Environment.NewLine, messages));
            }
            else
            {
                Console.WriteLine("None");
            }
        }
    }
}