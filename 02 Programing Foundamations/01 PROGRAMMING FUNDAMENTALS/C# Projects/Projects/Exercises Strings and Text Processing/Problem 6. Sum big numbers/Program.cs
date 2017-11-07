using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_6.Sum_big_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            if (first == "0" && second == "0")
            {
                Console.WriteLine(0);
            }
            else if (first == "0" || second == "0")
            {
                if (first == "0") Console.WriteLine(second);
                else Console.WriteLine(first);
            }
            else
            {
                char[] v1 = first.TrimStart('0').ToCharArray().Reverse().ToArray();
                char[] v2 = second.TrimStart('0').ToCharArray().Reverse().ToArray();
                int maxL = Math.Max(v1.Length, v2.Length);
                int minL = Math.Min(v1.Length, v2.Length);
                char[] rest = new char[maxL];
                if (v1.Length > v2.Length)
                {
                    rest = v1;
                }
                else
                {
                    rest = v2;
                }

                int next = 0;
                List<int> summary = new List<int>(maxL + 2);
                for (int i = 0; i < maxL; i++)
                {
                    int sum;
                    if (i < minL)
                    {
                        int a = int.Parse(v1[i].ToString());
                        int b = int.Parse(v2[i].ToString());
                        sum = a + b + next;
                        next = sum / 10;
                        sum = sum % 10;
                        summary.Add(sum);
                    }
                    else
                    {
                        int a = int.Parse(rest[i].ToString());
                        sum = a + next;
                        next = sum / 10;
                        sum = sum % 10;
                        summary.Add(sum);
                    }
                }
                if (next != 0)
                    summary.Add(next);
                summary.Reverse();
                Console.WriteLine(string.Join("", summary));
            }
        }
    }
}
