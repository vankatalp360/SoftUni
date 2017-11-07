using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___19.Thea_the_Photographer
{
    class Program
    {
        static void Main(string[] args)
        {
            uint N = uint.Parse(Console.ReadLine());//N – the amount of pictures Thea had taken,
            uint FT = uint.Parse(Console.ReadLine());//integer FT – the amount of time (filter time) in seconds that Thea will require to filter every single picture,
            uint FF = uint.Parse(Console.ReadLine());//integer FF – the filter factor or the percentage of the total pictures that are considered “good” to be uploaded,
            uint UT = uint.Parse(Console.ReadLine());//integer UT – the amount of time needed for every filtered picture to be uploaded to her storage,
            uint UseFullPics = (uint)Math.Ceiling((decimal)N * FF / 100); //Console.WriteLine(UseFullPics);

            ulong TotalTime = (ulong)N * (ulong)FT; //Console.WriteLine(TotalTime);

            TotalTime += (ulong)UseFullPics * (ulong)UT; //Console.WriteLine(TotalTime);

            ulong Days = TotalTime / 60 / 60 / 24;
            TotalTime = TotalTime - Days * 60 * 60 * 24;
            uint Hours = (uint)TotalTime / 60 / 60;
            TotalTime = TotalTime - Hours * 60 * 60;
            uint Minutes = (uint)TotalTime / 60;
            TotalTime = TotalTime - Minutes * 60;
            uint Seconds = (uint)TotalTime;
            Console.WriteLine("{0}:{1:00}:{2:00}:{3:00}", Days, Hours, Minutes, Seconds);

            //TimeSpan TimeInSeconds = TimeSpan.FromSeconds(TotalTime);
            //string totalTime = TimeInSeconds.ToString(@"d\:hh\:mm\:ss");
            //Console.WriteLine(totalTime);


        }
    }
}
