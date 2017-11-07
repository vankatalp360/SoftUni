using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Files
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[] separators = new char[] { '\\', ';' };
            Dictionary<string, Dictionary<string, long>> Files = new Dictionary<string, Dictionary<string, long>>();
            for (int i = 1; i <= n; i++)
            {
                string[] letters = Console.ReadLine().Trim().Split(separators, StringSplitOptions.RemoveEmptyEntries).ToArray();
                int lettersLength = letters.Length;
                string fileRoot = letters[0];
                string fileName = letters[lettersLength - 2];
                long fileSize = long.Parse(letters[lettersLength - 1]);
                if (Files.ContainsKey(fileRoot))
                {
                    Dictionary<string, long> currentRoot = Files[fileRoot];
                    currentRoot[fileName] = fileSize;
                }
                else
                {
                    Dictionary<string, long> currentRoot = new Dictionary<string, long>();
                    currentRoot[fileName] = fileSize;
                    Files.Add(fileRoot, currentRoot);
                }
            }
            string[] extensionRoot = Console.ReadLine().Split().ToArray();
            string root = extensionRoot[2];
            string extension = extensionRoot[0];
                        if (!Files.ContainsKey(root)) Console.WriteLine("No");
            else
            {
                Dictionary<string, long> currentRoot = Files[root];
                currentRoot = currentRoot.OrderByDescending(pair => pair.Value)
          .ThenBy(pair => pair.Key)
          .ToDictionary(pair => pair.Key,
                   pair => pair.Value);
                string Letter = "No";
                foreach (var pair in currentRoot)
                {
                    string[] currentFile = pair.Key.Split(new char[] { '.' }).ToArray();
                    string currentFileExtension = currentFile[currentFile.Length-1];
                    if (currentFileExtension != extension) continue;
                    else
                    {
                        Console.WriteLine($"{pair.Key} - {pair.Value} KB");
                        Letter = "Yes";
                    }
                }
                if (Letter == "No") Console.WriteLine(Letter);
            }
        }
    }
}
