using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> InputNumberList = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int number = numbers[0];
            int power = numbers[1];
            while (InputNumberList.Contains(number) == true)
            {
                int index = InputNumberList.IndexOf(number);
                int start;
                if (index - power < 0) start = 0; else start = index - power;
                int end;
                if (index + power > InputNumberList.Count-1) end = InputNumberList.Count; else end = index + power+1;                          
                InputNumberList.RemoveRange(start, end - start);                
            }
            Console.WriteLine($"{InputNumberList.Sum()}");
        }
    }
}
