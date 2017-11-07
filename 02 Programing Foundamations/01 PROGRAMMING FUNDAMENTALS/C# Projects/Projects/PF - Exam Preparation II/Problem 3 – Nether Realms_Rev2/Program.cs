using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_3___Nether_Realms_Rev2
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            string patternNames = @"\ *\,\ *";
            string[] demonsName = Regex.Split(Console.ReadLine(), patternNames).OrderBy(x => x).ToArray();
            foreach (string demon in demonsName)
            {
                int totalHealth = CalculateTotalHealth(demon);
                double totalDamage = CalculateTotalDamage(demon);
                Console.WriteLine($"{demon} - {totalHealth} health, {totalDamage:f2} damage");
            }
        }

        private static double CalculateTotalDamage(string demon)
        {
            string patternDamage = @"([-+]?\d+\.?\d*)?";
            string[] charDamage = Regex.Matches(demon, patternDamage)
                .Cast<Match>().Select(x => x.Value).ToArray();
            double totalDamage = 0;
            foreach (string letter in charDamage)
            {
                double number;
                bool result = double.TryParse(letter, out number);
                if (result)
                {
                    totalDamage += number;
                }
            }
            for (int i = 0; i < demon.Length; i++)
            {
                if (demon[i] == '*')
                {
                    totalDamage *= 2;
                }
                else if (demon[i] == '/')
                {
                    totalDamage /= 2;
                }
            }

            return totalDamage;
        }

        private static int CalculateTotalHealth(string demon)
        {
            string patternHealth = @"[^0-9+\-\*\/\.]";
            string[] charHealth = Regex.Matches(demon, patternHealth)
                .Cast<Match>().Select(x => x.Value).ToArray();

            int totalHealth = 0;
            for (int i = 0; i < charHealth.Length; i++)
            {
                totalHealth += charHealth[i][0];
            }

            return totalHealth;
        }
    }
}
