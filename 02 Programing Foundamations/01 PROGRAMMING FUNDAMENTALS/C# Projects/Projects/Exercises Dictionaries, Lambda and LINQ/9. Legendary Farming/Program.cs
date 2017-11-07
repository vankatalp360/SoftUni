using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separator = new char[] { ' ' };
            SortedDictionary<string, int> MaterialsAndQuantities = new SortedDictionary<string, int>();
            bool Exist = false;
            while (!Exist)
            {
                string[] currentMaterials = Console.ReadLine().ToLower().Split(separator, StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int i = 1; i < currentMaterials.Length; i += 2)
                {
                    if (MaterialsAndQuantities.ContainsKey(currentMaterials[i]))
                    {

                        MaterialsAndQuantities[currentMaterials[i]] += int.Parse(currentMaterials[i - 1]);
                    }
                    else MaterialsAndQuantities[currentMaterials[i]] = int.Parse(currentMaterials[i - 1]);
                    if ((currentMaterials[i] == "shards" || currentMaterials[i] == "fragments" || currentMaterials[i] == "motes") && MaterialsAndQuantities[currentMaterials[i]] >= 250)
                    {
                        Exist = true;
                        string LegendaryItem;
                        switch (currentMaterials[i])
                        {
                            case "shards":
                                LegendaryItem = "Shadowmourne";
                                break;
                            case "fragments":
                                LegendaryItem = "Valanyr";
                                break;
                            case "motes":
                                LegendaryItem = "Dragonwrath";
                                break;
                            default:
                                LegendaryItem = null;
                                break;
                        }
                        MaterialsAndQuantities[currentMaterials[i]] = MaterialsAndQuantities[currentMaterials[i]] - 250;
                        Console.WriteLine($"{LegendaryItem} obtained!");
                        MaterialsAndQuantities.OrderBy(x => x.Value);
                        Dictionary<string, int> MainMaterial = new Dictionary<string, int>();
                        if (MaterialsAndQuantities.ContainsKey("fragments"))
                        {
                            MainMaterial.Add("fragments", MaterialsAndQuantities["fragments"]);
                            MaterialsAndQuantities.Remove("fragments");
                        }
                        else
                        {
                            MainMaterial.Add("fragments", 0);
                        }
                        if (MaterialsAndQuantities.ContainsKey("motes"))
                        {
                            MainMaterial.Add("motes", MaterialsAndQuantities["motes"]);
                            MaterialsAndQuantities.Remove("motes");
                        }
                        else
                        {
                            MainMaterial.Add("motes", 0);
                        }
                        if (MaterialsAndQuantities.ContainsKey("shards"))
                        {
                            MainMaterial.Add("shards", MaterialsAndQuantities["shards"]);
                            MaterialsAndQuantities.Remove("shards");
                        }
                        else
                        {
                            MainMaterial.Add("shards", 0);
                        }

                        var OrderedMainMaterial = MainMaterial.OrderByDescending(pair => pair.Value)
            .ThenBy(pair => pair.Key)
            .ToDictionary(pair => pair.Key,
                     pair => pair.Value);
                        foreach (var pair in OrderedMainMaterial)
                        {
                            Console.WriteLine($"{pair.Key}: {pair.Value}");
                        }
                        foreach (var pair in MaterialsAndQuantities)
                        {
                            Console.WriteLine($"{pair.Key}: {pair.Value}");
                        }
                        break;
                    }
                }
            }
        }
    }
}

