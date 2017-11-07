using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___2.Track_Downloader
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> BlacklistedWords = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            char[] separator = { ' ', '.', '-' };
            List<string> Filenames = new List<string>();
            while (true)
            {
                string Filename = Console.ReadLine();
                if (Filename == "end") break;
                List<string> FilenameWords = Filename.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList();

                bool contain = false;
                for (int i = 0; i < BlacklistedWords.Count; i++)
                {
                    if (Filename.Contains(BlacklistedWords[i]))
                    {
                        contain = true;
                        break;
                    }
                }
                if (!contain) Filenames.Add(Filename);
            }
            Filenames.Sort();
            foreach (string letter in Filenames)
            {
                Console.WriteLine(letter);
            }
        }
    }
}
