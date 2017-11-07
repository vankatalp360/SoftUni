using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Morse_Code_Upgraded
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] letters = Console.ReadLine().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            char[] result = new char [letters.Length];
            for (int i =0; i< letters.Length;i++)
            {
                int sum = 0;
                foreach (var l in letters[i])
                {
                    if (l == '1') sum += 5;
                    else sum += 3;
                }
                sum = AddSequences(letters[i], sum);
               result[i]=((char)sum);
            }
            Console.WriteLine(string.Join("", result));
        }

        private static int AddSequences(string letter, int sum)
        {
            int countSequences = 0;
            foreach (var s in letter.Split(new char[] { '0' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).Where(x => x.Length > 1).ToArray())
            {
                countSequences += s.Length;
            }
            foreach (var s in letter.Split(new char[] { '1' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).Where(x => x.Length > 1).ToArray())
            {
                countSequences += s.Length;
            }
            sum += countSequences;
            return sum;
        }
    }
}
