using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___6.Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int Step = Numbers.Length / 4;
            int[] rowleft = Numbers.Take(Step).Reverse().ToArray();
            int[] rowright = Numbers.Reverse().Take(Step).ToArray();
            int[] rowup = rowleft.Concat(rowright).ToArray();
            int[] rowdown = Numbers.Skip(Step).Take(2 * Step).ToArray();
            int [] sumrows = rowup.Select((x, index) => x + rowdown[index]).ToArray();
            Console.WriteLine(string.Join(" ", sumrows));
        }
    }
}
