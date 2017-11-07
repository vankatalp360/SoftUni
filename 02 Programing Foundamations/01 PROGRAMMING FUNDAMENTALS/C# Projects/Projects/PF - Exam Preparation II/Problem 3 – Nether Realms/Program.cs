using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3___Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            string inputLetter = Console.ReadLine();
            string[] fightersNames = inputLetter.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            SortedDictionary<string, Dictionary<long, double>> fighters = new SortedDictionary<string, Dictionary<long, double>>();
            foreach (string name in fightersNames)
            {
                string fighterName = string.Join("", name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                char[] separators = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '+', '-', '/', '*', '.' };
                char[] Words = (string.Join("", fighterName.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToArray())).ToCharArray();
                long health = CalculateHealth(Words);
                int numberMultypliers, numberDeviders;
                DefineMultypliersAndDevidersNumber(fighterName, out numberMultypliers, out numberDeviders);
                double[] Numbers = DefineTheNumbers(fighterName, ref Words);
                double damage = CalculateDamage(numberMultypliers, numberDeviders, Numbers);
                DefineTheDictionary(fighters, fighterName, health, damage);
            }
            PrintingDictionary(fighters);
        }

        private static double[] DefineTheNumbers(string fighterName, ref char[] Words)
        {
            Words = Words.Concat("*" + "/").ToArray();
            double[] Numbers = fighterName.Split(Words, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            return Numbers;
        }

        private static void DefineTheDictionary(SortedDictionary<string, Dictionary<long, double>> fighters, string fighterName, long health, double damage)
        {
            Dictionary<long, double> UserNewIP = new Dictionary<long, double>();
            UserNewIP[health] = damage;
            fighters.Add(fighterName, UserNewIP);
        }

        private static void DefineMultypliersAndDevidersNumber(string fighterName, out int numberMultypliers, out int numberDeviders)
        {
            numberMultypliers = 0;
            numberDeviders = 0;
            for (int i = 0; i < fighterName.Length; i++)
            {
                if (fighterName[i] == '*') numberMultypliers++;
                if (fighterName[i] == '/') numberDeviders++;
            }
        }

        private static double CalculateDamage(int numberMultypliers, int numberDeviders, double[] Numbers)
        {
            double damage = 0;
            foreach (double i in Numbers)
                damage += i;
            for (int i = 0; i < numberMultypliers; i++)
            {
                damage *= 2;
            }
            for (int i = 0; i < numberDeviders; i++)
            {
                damage /= 2;
            }

            return damage;
        }

        private static long CalculateHealth(char[] Words)
        {
            long health = 0;
            foreach (char i in Words)
                health += i;
            return health;
        }

        private static void PrintingDictionary(SortedDictionary<string, Dictionary<long, double>> fighters)
        {
            foreach (var pair in fighters)
            {
                foreach (var value in pair.Value)
                {
                    Console.WriteLine($"{pair.Key} - {value.Key} health, {value.Value:F2} damage");
                }
            }
        }
    }
}
