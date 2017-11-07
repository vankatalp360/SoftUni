using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _6.Camera_View
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int m = numbers[0];
            int n = numbers[1];
            string pattern = @"(?<=(\|\<))(.*?)(?=($|(\|\<)))";
            List<string> regex = Regex.Matches(Console.ReadLine(), pattern)
                .Cast<Match>()
                .Select(x => x.Groups[2].Value)
                .Distinct()
                .ToList();
            List<string> result = new List<string>();
            foreach (string match in regex)
            {
                result.Add(string.Join("", match.Skip(m).Take(n)).Trim());
            }
            Console.WriteLine(string.Join(", ", result));
        }
    }
}