using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_6.Byte_Flip
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] numbers = Console.ReadLine().Split(' ').Where(x => x.Length == 2)
                .Select(x => string.Join("", x.ToCharArray().Reverse())).Reverse().Select(x => Convert.ToInt32(x, 16)).Select(x => (char)x).ToArray();
            Console.WriteLine(string.Join("", numbers));
        }
    }
}
