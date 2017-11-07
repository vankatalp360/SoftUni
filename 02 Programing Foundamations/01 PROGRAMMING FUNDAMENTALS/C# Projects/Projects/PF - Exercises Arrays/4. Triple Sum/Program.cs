using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Triple_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse). ToList();
            bool Contains=false;
            for (int i =0 ; i < Numbers.Count; i++)
            {
                for (int j = i+1; j <Numbers.Count; j ++)
                {
                    if (j == i) continue;
                    int temp = Numbers[i] + Numbers[j];
                    if (Numbers.Contains(temp)) { Console.WriteLine($"{Numbers[i]} + {Numbers[j]} == {temp}"); Contains = true; }
                }
            }
            if (!Contains) Console.WriteLine("No");
        }
    }
}
