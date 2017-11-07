using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___3.Equal_Sum_After_Extraction
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> FirstList = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> SecondList = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            RemoveNumbersFromSecondList(FirstList, SecondList);
            int FirstListSum = CalcutateSumOfList(FirstList);
            int SecondListSum = CalcutateSumOfList(SecondList);
            if (FirstListSum== SecondListSum)
            Console.WriteLine($"Yes. Sum: {FirstListSum}");
            else
                Console.WriteLine($"No. Diff: {Math.Abs(FirstListSum-SecondListSum)}");
        }
        private static void RemoveNumbersFromSecondList(List<int> FirstList, List<int> SecondList)
        {
            for (int i = 0; i < FirstList.Count; i++)
            {
                if (DoesSecondListContainNumber(FirstList[i], SecondList))
                {
                    SecondList.Remove(FirstList[i]);
                }
            }
        }
        private static bool DoesSecondListContainNumber(int i, List<int> SecondList)
        {
            bool Contains = SecondList.Contains(i);
            return Contains;
        }
        private static int CalcutateSumOfList (List<int> TheList)
        {
            int Sum = 0;
            foreach (int Number in TheList)
            {
                Sum += Number;
            }
            return Sum;
        }
    }
}
