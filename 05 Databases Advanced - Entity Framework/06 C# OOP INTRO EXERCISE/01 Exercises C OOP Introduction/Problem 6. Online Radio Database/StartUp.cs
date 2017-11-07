namespace Problem_6.Online_Radio_Database
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PlayList playList = new PlayList();
            for(int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Split(';');
                string artistName = input[0];
                string songName = input[1];
                string length = input[2];
                try
                {
                    Song song = new Song(artistName, songName, length);
                    playList.AddSong(song);                    
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(playList);
        }
    }
}
