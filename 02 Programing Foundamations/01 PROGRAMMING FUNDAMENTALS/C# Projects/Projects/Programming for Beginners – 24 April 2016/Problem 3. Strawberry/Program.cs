using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Strawberry
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for(int i = 0; i < number/2; i ++)
            {
                Console.WriteLine(new string('-',2*i)+"\\"+new string('-',number-2*i)+"|"+ new string('-', number -2* i) + "/"+ new string('-',2* i));
            }
            for(int i = 0; i < number/2+1; i++)
            {
                Console.WriteLine(new string('-', number-2*i)+"#"+new string('.', 2*i)+"." + new string('.', 2*i) + "#"+ new string('-', number - 2*i));
            }
            for (int i = number; i >= 0 ; i--)
            {
                Console.WriteLine(new string ('-', number - i) +"#"+ new string('.', i) + "." + new string('.', i) + "#" + new string('-', number - i));
            }
        }
    }
}
