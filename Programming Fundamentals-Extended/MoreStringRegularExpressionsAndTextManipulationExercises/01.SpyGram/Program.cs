using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.SpyGram
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            //   char[] charArr = {'T', 'O'};
            //   for (int i = 0; i < charArr.Length; i++)
            //   {
            //       charArr[i] += (char)3;
            //       Console.WriteLine(charArr[i]);
            //   }

            string pattern = @"^TO: [A-Z]+; MESSAGE: .+;$";
            string key = Console.ReadLine();
            string input = Console.ReadLine();
            List<string> messages = new List<string>();
            while (input != "END")
            {
                Match message = Regex.Match(input, pattern);
                if (message.Success)
                {
                    messages.Add(message.Value);
                }

                input = Console.ReadLine();
            }
            messages = messages.OrderBy(x => x[4]).ToList();
            List<string> results = new List<string>();
            foreach (string m in messages)
            {
                char[] text = m.ToCharArray();
                int count = 0;
                string newString = "";
                for (int i = 0; i < text.Length; i++)
                {
                    if (count == key.Length)
                    {
                        count = 0;
                    }
                    var x = int.Parse(key[count].ToString());
                    char letter = (char)(m[i] + x);
                    newString += letter;
                    count++;
                }
                results.Add(newString);               
            }
            foreach (var r in results)
            {
                Console.WriteLine(r);
            }
        }
    }
}