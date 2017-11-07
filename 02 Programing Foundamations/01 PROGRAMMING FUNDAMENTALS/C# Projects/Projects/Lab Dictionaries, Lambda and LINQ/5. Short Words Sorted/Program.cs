using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Short_Words_Sorted
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] seperators = { ' ', '.',',',':',';','(',')','[',']','"','\'','\\','/' ,'!','?'};
            List<string> words = Console.ReadLine().ToLower(). Split(seperators, StringSplitOptions.RemoveEmptyEntries).Distinct(). Where(x=>x.Length<5).OrderBy(x=>x). ToList();
            Console.WriteLine(string.Join(", ",words));
        }
    }
}
