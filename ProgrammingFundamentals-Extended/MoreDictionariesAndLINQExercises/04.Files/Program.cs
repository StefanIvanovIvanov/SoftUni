using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04.Files
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, string>> paths = new Dictionary<string, Dictionary<string, string>>();
            //Dictionary<root, Dictionary<file , size>>
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] path = Console.ReadLine().Split(new[] { '\\', ';' }).ToArray();
                string root = path[0];
                string size = path[path.Length - 1];
                string file = path[path.Length - 2];

                if (!paths.ContainsKey(root))
                {
                    paths.Add(root, new Dictionary<string, string>());
                }
                if (!paths[root].ContainsKey(file))
                {
                    paths[root].Add(file, size);
                }
                paths[root][file] = size;
            }

            string[] searching = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string fileSearched = searching[0];
            string rootSearched = searching[2];

            bool isEmpty = true;
            foreach (var p in paths)
            {
                foreach (var file in p.Value.OrderByDescending(f=>f.Value).ThenBy(z=>z.Key))
                {
                    int index = file.Key.LastIndexOf('.');
                    string extension = file.Key.Substring(index+1);                   
                    if (fileSearched == extension && rootSearched == p.Key)
                    {
                        Console.WriteLine($"{file.Key} - {file.Value} KB");
                        isEmpty = false;
                    }
                }
            }
            if (isEmpty)
            {
                Console.WriteLine("No");
            }
        }
    }
}
