using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_7.Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] elements = Console.ReadLine().ToCharArray();
            bool result = true;
            Stack<char> seq1 = new Stack<char>();
            foreach (char element in elements)
            {
                switch (element)
                {
                    case '{':
                    case '[':
                    case '(':
                        seq1.Push(element);
                        break;
                    case '}':
                        if (seq1.Count == 0)
                            result = false;
                        else
                        {
                            char currentSeq1 = seq1.Pop();
                            if (currentSeq1 != '{')
                                result = false;
                        }
                        break;
                    case ']':
                        if (seq1.Count == 0)
                            result = false;
                        else
                        {
                            char currentSeq1 = seq1.Pop();
                            if (currentSeq1 != '[')
                                result = false;
                        }                        
                        break;
                    case ')':
                        if (seq1.Count == 0)
                            result = false;
                        else
                        {
                            char currentSeq1 = seq1.Pop();
                            if (currentSeq1 != '(')
                                result = false;
                        }
                        break;                    
                }
                if (!result)
                {
                    break;
                }
            }
            PrintResult(result);
        }

        private static void PrintResult(bool result)
        {
            if (!result)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
