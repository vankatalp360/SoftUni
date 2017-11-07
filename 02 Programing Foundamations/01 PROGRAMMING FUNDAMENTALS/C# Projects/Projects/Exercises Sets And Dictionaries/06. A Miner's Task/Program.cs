using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.A_Miner_s_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Goods> goods = new List<Goods>();
            while (true)
            {
                string resource = Console.ReadLine();
                if (resource == "stop") break;
                Goods current = new Goods();
                current.Name = resource;
                current.Quantity = int.Parse(Console.ReadLine());
                AddCurrentGood(goods, current);
            }
            PrintTheResult(goods);
        }

        private static void AddCurrentGood(List<Goods> goods, Goods current)
        {
            if (goods.Count == 0) goods.Add(current);
            else
            {
                bool contains = false;
                for (int i = 0; i < goods.Count; i++)
                {
                    if (goods[i].Name == current.Name)
                    {
                        goods[i].Quantity += current.Quantity;
                        contains = true;
                        break;
                    }
                }
                if (contains == false) goods.Add(current);
            }
        }

        private static void PrintTheResult(List<Goods> goods)
        {
            foreach (var good in goods)
            {
                Console.WriteLine($"{good.Name} -> {good.Quantity}");
            }
        }

        class Goods
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
        }
    }
}
