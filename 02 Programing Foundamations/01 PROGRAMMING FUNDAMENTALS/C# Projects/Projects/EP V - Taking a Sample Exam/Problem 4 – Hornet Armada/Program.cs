using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_4___Hornet_Armada
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(?<lastActivity>\d+)\s=\s(?<legionName>[^=->: ]+)\s\->\s(?<soldierType>[^=->: ]+):(?<soldierCount>\d+)$";
            Dictionary<string, Legion> armada = new Dictionary<string, Legion>();
            ReadArmadaData(pattern, armada);
            PrintResult(armada);
        }

        private static void PrintResult(Dictionary<string, Legion> armada)
        {
            string[] outputFormat = Console.ReadLine().Split(new[] { '\\' }, StringSplitOptions.None);

            if (outputFormat.Length > 1)
            {
                long activity = long.Parse(outputFormat[0]);
                string soldierType = outputFormat[1];
                foreach (var legion in armada.Where(x => x.Value.LastActivity < activity).Where(x=>x.Value.Solgiers.ContainsKey(soldierType))
                   .OrderByDescending(x => x.Value.Solgiers.Where(y=>y.Key==soldierType). Select(y=>y.Value).Single()))
                {
                    Console.WriteLine($"{legion.Key} -> {legion.Value.Solgiers[soldierType]}");
                }
            }
            else
            {
                foreach (var legion in armada.OrderByDescending(x => x.Value.LastActivity))
                {
                    foreach (var solgiers in legion.Value.Solgiers.Where(x => x.Key == outputFormat[0]))
                    {
                        Console.WriteLine($"{legion.Value.LastActivity} : {legion.Key}");
                    }
                }
            }
        }


        private static void ReadArmadaData(string pattern, Dictionary<string, Legion> armada)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Match match = Regex.Match(Console.ReadLine(), pattern);
                if (match.Success)
                {
                    int lastActivity = int.Parse(match.Groups["lastActivity"].Value);
                    string legionName = match.Groups["legionName"].Value;
                    string soldierType = match.Groups["soldierType"].Value;
                    int soldierCount = int.Parse(match.Groups["soldierCount"].Value);
                    if (!armada.ContainsKey(legionName))
                    {
                        armada[legionName] = new Legion();
                        armada[legionName].LegionName = legionName;
                        armada[legionName].LastActivity = lastActivity;
                        armada[legionName].Solgiers = new Dictionary<string, long>() { { soldierType, soldierCount } };
                    }
                    else
                    {
                        if (!armada[legionName].Solgiers.ContainsKey(soldierType))
                        {
                            armada[legionName].Solgiers.Add(soldierType, soldierCount);
                        }
                        else
                        {
                            armada[legionName].Solgiers[soldierType] += soldierCount;
                        }
                        if (armada[legionName].LastActivity < lastActivity)
                        {
                            armada[legionName].LastActivity = lastActivity;
                        }
                    }
                }

            }
        }

        class Legion
        {
            public string LegionName { get; set; }
            public long LastActivity { get; set; }
            public Dictionary<string, long> Solgiers { get; set; }
        }
    }
}

