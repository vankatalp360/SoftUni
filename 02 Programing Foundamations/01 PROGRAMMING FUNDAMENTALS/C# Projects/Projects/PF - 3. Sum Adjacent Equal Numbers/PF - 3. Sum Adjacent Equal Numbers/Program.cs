using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___3.Sum_Adjacent_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> InputList = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
            while (true)
            {
                bool Result = false;
                for (int i = 0; i < InputList.Count - 1; i++)
                {
                    double First = InputList[i];
                    double Second = InputList[i + 1];
                    if (First == Second)
                    {
                        double Sum = First + Second;
                        InputList.RemoveRange(i, 2);
                        InputList.Insert(i, Sum);
                        Result = true;
                    }
                }
                if (!Result) break;
            }
            Console.WriteLine(string.Join(" ", InputList));
        }
    }
}
