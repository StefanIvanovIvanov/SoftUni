using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            List<string> listOfWords = new List<string>();
            using (StreamReader readWords = new StreamReader(@"D:\SoftUni\C# Advanced\Упражнения\03.Streams-Exercise\03.WordCount\words.txt"))
            {
                string newWord = readWords.ReadLine();
                while (newWord != null)
                {
                    words.Add(newWord.Trim(), 0);
                    listOfWords.Add(newWord);

                    newWord = readWords.ReadLine();
                }
            }
            using (StreamReader readWords = new StreamReader(@"D:\SoftUni\C# Advanced\Упражнения\03.Streams-Exercise\03.WordCount\text.txt"))
            {
                string text = readWords.ReadToEnd();
                while (text != null)
                {
                    foreach (var word in listOfWords)
                    {
                        string[] array = text.Split(new[] {' ','-','!','?','.',','}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i].ToLower() == word)
                            {
                                words[word]++;
                            }
                        }
                    }
                    text = readWords.ReadLine();
                }
                using (StreamWriter writeStream = new StreamWriter(@"D:\SoftUni\C# Advanced\Упражнения\03.Streams-Exercise\03.WordCount\result.txt"))
                {
                    foreach (var word in words.OrderByDescending(w => w.Value))
                    {
                        writeStream.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
            }
        }
    }
}
