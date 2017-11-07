using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDir = Directory.GetCurrentDirectory();

            double totalLenght = 0;

            var dirInfo = new DirectoryInfo(currentDir + "\\TestFolder");

            totalLenght = NewMethod(totalLenght, dirInfo);

            Console.WriteLine(totalLenght / 1024 / 1024);
        }

        private static double NewMethod(double totalLenght, DirectoryInfo dirInfo)
        {
            foreach (var subDir in dirInfo.GetDirectories())
            {
                Console.WriteLine($"* {subDir.Name}:");
                NewMethod(totalLenght, subDir);

            }

            foreach (var file in dirInfo.GetFiles())
            {
                Console.WriteLine($"--> {file.Name}");
                var fileInfo = new FileInfo(file.FullName);
                totalLenght += fileInfo.Length;
            }
            Console.WriteLine(totalLenght);
            return totalLenght;
        }
    }
}
