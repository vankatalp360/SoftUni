using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___5.Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> InputLetter = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> BumbAndPower = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int Bumb = BumbAndPower[0];
            int Power = BumbAndPower[1];
            bool[] ConvertedList = new bool[InputLetter.Count];
            for (int i = 0; i < InputLetter.Count; i++)
            {
                if (ConvertedList[i] == false && InputLetter[i] == Bumb)
                {
                    for (int j = 0; j <= Power; j++)
                    {
                        if (i - j >= 0) ConvertedList[i - j] = true;
                        if (i + j < InputLetter.Count) ConvertedList[i + j] = true;
                    }
                }
            }
            int Sum = 0;
            for (int i = 0; i < InputLetter.Count; i++)
            {
                if (ConvertedList[i] == false) Sum += InputLetter[i];
            }
            Console.WriteLine(Sum);
        }
    }
}
