namespace Problem_6.Online_Radio_Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayList
    {
        private List<Song> songs;

        public PlayList()
        {
            this.songs = new List<Song>();
        }

        public void AddSong(Song song)
        {
            this.songs.Add(song);

            Console.WriteLine("Song added.");
        }

        private int TotalLegth()
        {
            return this.songs.Sum(x => x.Length);
        }

        public override string ToString()
        {
            int totalLength = TotalLegth();
            int hours = totalLength / 3600;
            int minutes = totalLength%3600 / 60;
            int seconds = totalLength - hours * 3600 - minutes * 60;
            return $"Songs added: {this.songs.Count}"+Environment.NewLine+$"Playlist length: {hours}h {minutes}m {seconds}s";
        }
    }
}
