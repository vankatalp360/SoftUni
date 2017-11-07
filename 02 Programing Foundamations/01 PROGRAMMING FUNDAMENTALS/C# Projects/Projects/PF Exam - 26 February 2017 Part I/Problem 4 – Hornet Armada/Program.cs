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
            string pattern = @"^(?<lastActivity>\d+)\s=\s(?<legionName>.+)\s\->\s(?<soldierType>.+):(?<soldierCount>\d+)$";
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Legion> legionLog = new Dictionary<string, Legion>(n);
            DefineTheLegions(pattern, n, legionLog);
            PrintResult(legionLog);
        }

        private static void PrintResult(Dictionary<string, Legion> legionLog)
        {
            string[] commands = Console.ReadLine().Split('\\').ToArray();
            if (commands.Length == 2)
            {
                int activity = int.Parse(commands[0]);
                string solgierType = commands[1];
                foreach (var legion in legionLog.Where(x => x.Value.LastActivity < activity)
                    .OrderByDescending(x => x.Value.Soldeirs
                    .Where(y => y.SoldierType == solgierType)
                    .Select(y => y.SoldierCount).Sum()))
                {
                    foreach (var solgier in legion.Value.Soldeirs.Where(x => x.SoldierType == solgierType))
                    {
                        Console.WriteLine($"{legion.Key} -> {solgier.SoldierCount}");
                    }
                }
            }
            else if (commands.Length == 1)
            {
                string solgierType = commands[0];
                foreach (var legion in legionLog.OrderByDescending(x => x.Value.LastActivity))
                {
                    foreach (var solgiers in legion.Value.Soldeirs.Where(x => x.SoldierType == solgierType))
                    {
                        Console.WriteLine($"{legion.Value.LastActivity} : {legion.Key}");
                    }
                }
            }
        }

        private static void DefineTheLegions(string pattern, int n, Dictionary<string, Legion> legionLog)
        {
            for (int i = 1; i <= n; i++)
            {
                Match current = Regex.Match(Console.ReadLine(), pattern);
                if (current.Success)
                {
                    var lastActivity = int.Parse(current.Groups["lastActivity"].Value);
                    var legionName = current.Groups["legionName"].Value;
                    var soldierType = current.Groups["soldierType"].Value;
                    var soldierCount = int.Parse(current.Groups["soldierCount"].Value);
                    if (!legionLog.ContainsKey(legionName))
                    {
                        legionLog[legionName] = new Legion();
                        legionLog[legionName].LastActivity = lastActivity;
                        legionLog[legionName].Soldeirs = new List<Soldier>();
                        legionLog[legionName].LegionName = legionName;
                    }
                    if (legionLog[legionName].LastActivity < lastActivity) legionLog[legionName].LastActivity = lastActivity;
                    if (!legionLog[legionName].Soldeirs.Select(x => x.SoldierType).Contains(soldierType))
                    {
                        Soldier newSoldier = new Soldier();
                        newSoldier.SoldierType = soldierType;
                        newSoldier.SoldierCount = soldierCount;
                        legionLog[legionName].Soldeirs.Add(newSoldier);
                    }
                    else
                    {
                        foreach (var j in legionLog[legionName].Soldeirs.Where(x => x.SoldierType == soldierType))
                        {
                            j.SoldierCount += soldierCount;
                        }
                    }
                }
            }
        }
    }
    class Legion
    {
        public string LegionName { get; set; }
        public List<Soldier> Soldeirs { get; set; }
        public int LastActivity { get; set; }
    }
    class Soldier
    {
        public string SoldierType { get; set; }
        public long SoldierCount { get; set; }
    }
}
