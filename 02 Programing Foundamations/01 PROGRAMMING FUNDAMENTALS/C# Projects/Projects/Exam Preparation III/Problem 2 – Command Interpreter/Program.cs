using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2___Command_Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Letters = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] Commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (Commands[0] != "end")
            {
                int length = Letters.Length;
                switch (Commands[0])
                {
                    case "reverse":
                        int start = int.Parse(Commands[2]);
                        int count = int.Parse(Commands[4]);
                        if (start < 0 || count < 0 || start + count > length || start >= length)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }
                        Letters = SortOrReverseArray(Letters, start, count, "reverse");
                        break;
                    case "sort":
                        start = int.Parse(Commands[2]);
                        count = int.Parse(Commands[4]);
                        if (start < 0 || count < 0 || start + count > length||start>=length)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }
                        Letters = SortOrReverseArray(Letters, start, count, "sort");
                        break;
                    case "rollLeft":
                        count = int.Parse(Commands[1]);
                        if (count < 0)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }
                        Letters = MoveLeftArray(Letters, count % length);
                        break;
                    case "rollRight":
                        count = int.Parse(Commands[1]);
                        if (count < 0)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }
                        Letters = MoveLeftArray(Letters.Reverse().ToArray(), count % length).Reverse().ToArray();
                        break;
                }
                Commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            Console.WriteLine($"[{string.Join(", ", Letters)}]");
        }
        private static string[] SortOrReverseArray(string[] Letters, int start, int count, string command)
        {
            string[] row1 = Letters.Take(start).ToArray();
            string[] row2;
            if (command == "sort") row2 = Letters.Skip(start).Take(count).OrderBy(x => x).ToArray();
            else row2 = Letters.Skip(start).Take(count).Reverse().ToArray();
            string[] row3 = Letters.Reverse().Take(Letters.Length - start - count).Reverse().ToArray();
            row1 = row1.Concat(row2).Concat(row3).ToArray();
            return row1;
        }
        private static string[] MoveLeftArray(string[] Letters, int start)
        {
            string[] row1 = Letters.Take(start).ToArray();
            string[] row2 = Letters.Reverse().Take(Letters.Length - start).Reverse().ToArray();
            row2 = row2.Concat(row1).ToArray();
            return row2;
        }
    }
}
