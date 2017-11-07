using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Jarvis
{
    class Program
    {
        static void Main(string[] args)
        {
            long maxEnergyCapacity = long.Parse(Console.ReadLine());
            Robot myRobot = DefMyRobot();
            while (true)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                if (input[0] == "Assemble!") break;
                ReadComponents(myRobot, input);
            }
            OrderMyRobotComponents(myRobot);
            bool hasEnoughEnergy = CalculateEnergy(myRobot, maxEnergyCapacity);
            if (!hasEnoughEnergy) return;
            bool hasEnoughParts = CalculateParts(myRobot);
            if (!hasEnoughParts)
            {
                Console.WriteLine($"We need more parts!");
                return;
            }
            PrintRobotInfo(myRobot);
        }

        private static void PrintRobotInfo(Robot myRobot)
        {
            Console.WriteLine($"{myRobot.Name}:");
            foreach (var head in myRobot.Head)
            {
                Console.WriteLine($"#{head.Name}:");
                Console.WriteLine($"###Energy consumption: {head.EnergyConsumption}");
                Console.WriteLine($"###IQ: {head.IQ}");
                Console.WriteLine($"###Skin material: {head.SkinMterial}");
            }
            foreach (var torso in myRobot.Torso)
            {
                Console.WriteLine($"#{torso.Name}:");
                Console.WriteLine($"###Energy consumption: {torso.EnergyConsumption}");
                Console.WriteLine($"###Processor size: {torso.ProcessorSizeInCentimeters:f1}");
                Console.WriteLine($"###Corpus material: {torso.HousingMaterial}");
            }
            foreach (var arm in myRobot.Arms)
            {
                Console.WriteLine($"#{arm.Name}:");
                Console.WriteLine($"###Energy consumption: {arm.EnergyConsumption}");
                Console.WriteLine($"###Reach: {arm.ArmReachDistance}");
                Console.WriteLine($"###Fingers: {arm.CountOfFingers}");
            }
            foreach (var leg in myRobot.Legs)
            {
                Console.WriteLine($"#{leg.Name}:");
                Console.WriteLine($"###Energy consumption: {leg.EnergyConsumption}");
                Console.WriteLine($"###Strength: {leg.Strength}");
                Console.WriteLine($"###Speed: {leg.Speed}");
            }
        }

        private static bool CalculateParts(Robot myRobot)
        {
            if (myRobot.Arms.Count < 2) return false;
            else if (myRobot.Legs.Count < 2) return false;
            else if (myRobot.Torso.Count < 1) return false;
            else if (myRobot.Head.Count < 1) return false;
            else return true;
        }

        private static bool CalculateEnergy(Robot myRobot, long maxEnergyCapacity)
        {

            long totalEnergy = myRobot.Arms.Select(x => (long)x.EnergyConsumption).Sum()
                + myRobot.Legs.Select(x => (long)x.EnergyConsumption).Sum()
                + myRobot.Torso.Select(x => (long)x.EnergyConsumption).Sum()
                + myRobot.Head.Select(x => (long)x.EnergyConsumption).Sum();
            if (totalEnergy > maxEnergyCapacity)
            {
                Console.WriteLine($"We need more power!");
                return false;
            }
            return true;
        }

        private static void OrderMyRobotComponents(Robot myRobot)
        {
            myRobot.Arms = myRobot.Arms.OrderBy(x => x.EnergyConsumption).Take(2).ToList();
            myRobot.Legs = myRobot.Legs.OrderBy(x => x.EnergyConsumption).Take(2).ToList();
            myRobot.Torso = myRobot.Torso.OrderBy(x => x.EnergyConsumption).Take(1).ToList();
            myRobot.Head = myRobot.Head.OrderBy(x => x.EnergyConsumption).Take(1).ToList();
        }

        private static Robot DefMyRobot()
        {
            Robot myRobot = new Robot();
            myRobot.Arms = new List<Arm>();
            myRobot.Legs = new List<Leg>();
            myRobot.Torso = new List<Torso>();
            myRobot.Head = new List<Head>();
            return myRobot;
        }

        private static void ReadComponents(Robot myRobot, string[] input)
        {
            string typeOfComponent = input[0];
            if (long.Parse(input[1])== (int)long.Parse(input[1]))            
            switch (typeOfComponent)
            {
                case "Arm":
                    Arm newArm = new Arm();
                    newArm.EnergyConsumption = int.Parse(input[1]);
                    newArm.ArmReachDistance = int.Parse(input[2]);
                    newArm.CountOfFingers = int.Parse(input[3]);
                    myRobot.Arms.Add(newArm);
                    break;
                case "Leg":
                    Leg newLeg = new Leg();
                    newLeg.EnergyConsumption = int.Parse(input[1]);
                    newLeg.Strength = int.Parse(input[2]);
                    newLeg.Speed = int.Parse(input[3]);
                    myRobot.Legs.Add(newLeg);
                    break;
                case "Torso":
                    Torso newTorso = new Torso();
                    newTorso.EnergyConsumption = int.Parse(input[1]);
                    newTorso.ProcessorSizeInCentimeters = double.Parse(input[2]);
                    newTorso.HousingMaterial = input[3];
                    myRobot.Torso.Add(newTorso);
                    break;
                case "Head":
                    Head newHead = new Head();
                    newHead.EnergyConsumption = int.Parse(input[1]);
                    newHead.IQ = int.Parse(input[2]);
                    newHead.SkinMterial = input[3];
                    myRobot.Head.Add(newHead);
                    break;
                default:
                    break;
            }
        }
    }
    class Robot
    {
        public string Name { get { return "Jarvis"; } }
        public List<Arm> Arms { get; set; }
        public List<Leg> Legs { get; set; }
        public List<Torso> Torso { get; set; }
        public List<Head> Head { get; set; }
    }
    class Arm
    {
        public string Name { get { return "Arm"; } }
        public int EnergyConsumption { get; set; }
        public int ArmReachDistance { get; set; }
        public int CountOfFingers { get; set; }
    }
    class Leg
    {
        public string Name { get { return "Leg"; } }
        public int EnergyConsumption { get; set; }
        public int Strength { get; set; }
        public int Speed { get; set; }
    }
    class Torso
    {
        public string Name { get { return "Torso"; } }
        public int EnergyConsumption { get; set; }
        public double ProcessorSizeInCentimeters { get; set; }
        public string HousingMaterial { get; set; }
    }
    class Head
    {
        public string Name { get { return "Head"; } }
        public int EnergyConsumption { get; set; }
        public int IQ { get; set; }
        public string SkinMterial { get; set; }
    }
}

