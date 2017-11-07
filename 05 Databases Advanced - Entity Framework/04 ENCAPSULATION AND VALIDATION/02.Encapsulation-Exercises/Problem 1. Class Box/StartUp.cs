namespace Problem_1.Class_Box
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Box box = new Box(length, width, height);
            Console.WriteLine($"Surface Area - {box.CalcSurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {box.CalcLateralSurfaceArea():f2}");
            Console.WriteLine($"Volume - {box.CalcVolume():f2}");

        }
    }
}
