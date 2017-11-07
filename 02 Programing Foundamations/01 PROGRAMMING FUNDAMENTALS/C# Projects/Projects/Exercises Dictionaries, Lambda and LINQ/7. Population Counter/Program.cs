using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Population_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separator = new char[] { '|' };
            Dictionary<string, Dictionary<string, long>> ContriesCitiesAndPopulation = new Dictionary<string, Dictionary<string, long>>();
            while (true)
            {
                string[] currentCity = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (currentCity[0].ToUpper() == "REPORT") break;
                else
                {
                    if (ContriesCitiesAndPopulation.ContainsKey(currentCity[1]))
                    {
                        Dictionary<string, long> CurrentCity = ContriesCitiesAndPopulation[currentCity[1]];
                        if (CurrentCity.ContainsKey(currentCity[0]))
                        {
                            CurrentCity[currentCity[0]] += long.Parse(currentCity[2]);
                        }
                        else CurrentCity[currentCity[0]] = long.Parse(currentCity[2]);
                    }
                    else
                    {
                        Dictionary<string, long> NewCity = new Dictionary<string, long>();
                        NewCity[currentCity[0]] = long.Parse(currentCity[2]);
                        ContriesCitiesAndPopulation.Add(currentCity[1], NewCity);
                    }
                }
            }
            ContriesCitiesAndPopulation = ContriesCitiesAndPopulation.OrderByDescending(pair => pair.Value.Sum(x => x.Value))
            .ThenBy(pair => pair.Key)
            .ToDictionary(pair => pair.Key,
                     pair => pair.Value);
            foreach (var pair in ContriesCitiesAndPopulation)
            {
                var OrderedCitiesAndPopulation = pair.Value.OrderByDescending(i => i.Value);
                long sum = pair.Value.Sum(x => x.Value);
                Console.WriteLine($"{pair.Key} (total population: {sum})");
                foreach (var value in OrderedCitiesAndPopulation)
                {
                    Console.WriteLine($"=>{value.Key}: {value.Value}");
                }
            }
        }
    }
}
