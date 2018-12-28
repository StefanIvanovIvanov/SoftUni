using System;
using System.IO;
using System.Linq;

namespace _02.IndexOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt").ToLower();
            string[] alphabet = new string[]
                {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"};
            
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (input[i].ToString() == alphabet[j])
                    {
                        File.AppendAllText("output.txt", $"{input[i]} -> {j}"+ Environment.NewLine);
                    }
                }
            }
        }
    }
}