using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_6.Catch_the_Thief
{
    class Program
    {
        static void Main(string[] args)
        {
            string thiefsIdType = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            long maxValueInTheType = long.MaxValue;
            long minValueInTheType = long.MinValue;
            switch (thiefsIdType)
            {
                case "sbyte":
                    maxValueInTheType = sbyte.MaxValue;
                    minValueInTheType = sbyte.MinValue;
                    break;
                case "int":
                    maxValueInTheType = int.MaxValue;
                    minValueInTheType = int.MinValue;
                    break;
                case "long":
                    maxValueInTheType = long.MaxValue;
                    minValueInTheType = long.MinValue;
                    break;
            }
            long currentMax = long.MinValue;
            int counter = 0;
            for (int i = 1; i <= number; i++)
            {
                try
                {
                    BigInteger current = BigInteger.Parse(Console.ReadLine());
                    if ((BigInteger)minValueInTheType <= current && current <= (BigInteger)maxValueInTheType && current > currentMax)
                    {
                        currentMax = (long)current;
                        counter++;
                    }
                }
                catch
                {
                }
            }
            if (counter>0) Console.WriteLine(currentMax);
        }
    }
}
