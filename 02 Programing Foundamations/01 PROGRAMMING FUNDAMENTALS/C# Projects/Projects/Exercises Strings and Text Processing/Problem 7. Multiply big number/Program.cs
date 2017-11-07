using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_7.Multiply_big_number
{
    class Program
    {
        static void Main(string[] args)
        {
            string firts = Console.ReadLine();
            string second = Console.ReadLine();
            if (firts == "0" || second == "0")
            {
                Console.WriteLine(0);
            }
            else
            {
                List<int> v1 = firts.TrimStart('0').ToCharArray().Reverse().Select(x => int.Parse(x.ToString())).ToList();
                List<int> v2 = second.TrimStart('0').ToCharArray().Reverse().Select(x => int.Parse(x.ToString())).ToList();
                List<List<int>> summary = new List<List<int>>();
                MultiplyEveryNumber(v1, v2, summary);
                SumAllLists(summary);
                Console.WriteLine(string.Join("", summary[0]));
            }            
        }

        private static void MultiplyEveryNumber(List<int> v1, List<int> v2, List<List<int>> summary)
        {
            int v1Lenght = v1.Count;
            int v2Lenght = v2.Count;
            for (int i = 0; i < v1Lenght; i++)
            {
                for (int j = 0; j < v2Lenght; j++)
                {
                    List<int> zerosFirst = AddZeros(i);
                    summary.Add(zerosFirst);
                    List<int> zeros = AddZeros(j);
                    summary[summary.Count - 1].AddRange(zeros);
                    int a = v1[i];
                    int b = v2[j];
                    int mul = a * b;
                    int cur = mul % 10;
                    summary[summary.Count - 1].Add(cur);
                    int next = ((mul - cur) / 10);
                    if (next != 0) summary[summary.Count - 1].Add(next);
                }
            }
        }

        private static void SumAllLists(List<List<int>> summary)
        {
            while (summary.Count > 1)
            {
                summary.Add(SumTwoNumbetrs(summary[0], summary[1]));
                summary.RemoveRange(0, 2);
            }
            summary[0].Reverse();
        }

        private static List<int> SumTwoNumbetrs(List<int> v1, List<int> v2)
        {
            int maxL = Math.Max(v1.Count, v2.Count);
            int minL = Math.Min(v1.Count, v2.Count);
            List <int>rest = new List<int>(maxL);
            if (v1.Count > v2.Count)
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
            return summary;
        }

        private static List<int> AddZeros(int i)
        {
            List<int> result = new List<int>();
            for (int j = 1; j <= i; j++)
            {
                result.Add(0);
            }
            return result;
        }
    }
}
