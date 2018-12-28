using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _08.CubicsMessages
{
    class Program
    {
        static void Main(string[] args)
        {


            string input = Console.ReadLine();

            while (input != "Over!")
            {
                int m = int.Parse(Console.ReadLine());
                string pattern = "^([0-9]+)([A-Za-z]{" + m + "})([^A-Za-z]*)$";
                
                StringBuilder sb= new StringBuilder();
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string front = match.Groups[1].Value;
                    string text = match.Groups[2].Value;
                    string back = match.Groups[3].Value;

                    string resultStringFront = Regex.Match(front, @"\d+").Value;
                    string resultStringBack = Regex.Match(back, @"\d+").Value;
                    int lFront = text.Length;
                    if (resultStringFront.Length > 0)
                    {
                        for (int i = 0; i < resultStringFront.Length; i++)
                        {
                            int number = (int)resultStringFront[i]-48;
                            if (number < lFront)
                            {
                                sb.Append(text[number]);                              
                            }
                            else
                            {
                                sb.Append(" ");
                            }
                        }
                    }

                    if (resultStringBack.Length > 0)
                    {
                        for (int i = 0; i < resultStringBack.Length; i++)
                        {
                            int number = (int)resultStringBack[i] - 48;
                            if (number < lFront)
                            {
                                sb.Append(text[number]);
                            }
                            else
                            {
                                sb.Append(" ");
                            }
                        }
                    }

                    Console.WriteLine($"{text} == {sb.ToString()}");
                    sb.Clear();
                }
                input = Console.ReadLine();
            }
        }
    }
}