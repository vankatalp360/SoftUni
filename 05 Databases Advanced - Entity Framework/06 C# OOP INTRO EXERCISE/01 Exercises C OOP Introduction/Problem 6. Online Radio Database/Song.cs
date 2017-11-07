namespace Problem_6.Online_Radio_Database
{
    using System;
    using System.Linq;

    public class Song
    {
        private string artistName;
        private string songName;
        private int length;
        private int minutes;
        private int seconds;

        internal Song(string artistName, string songName, string length)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            ModifyInputLength(length);
        }

        public string ArtistName
        {
            get
            {
                return this.artistName;
            }
            private set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
                }
                this.artistName = value;
            }
        }

        public string SongName
        {
            get
            {
                return this.songName;
            }
            private set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new ArgumentException("Song name should be between 3 and 30 symbols.");
                }
                this.songName = value;
            }
        }

        private int Minutes
        {
            get
            {
                return this.minutes;
            }
            set
            {
                if (value < 0 || value > 14)
                {
                    throw new ArgumentException("Song minutes should be between 0 and 14.");
                }
                this.minutes = value;
            }
        }

        private int Seconds
        {
            get
            {
                return this.seconds;
            }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException("Song seconds should be between 0 and 59.");
                }
                this.seconds = value;
            }
        }

        public int Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if(value<=0)
                {
                    throw new ArgumentException("Invalid song length.");
                }
                this.length = value;
            }
        }

        private void ModifyInputLength(string length)
        {
            string[] input = length.Split(':');
            if (input.Length != 2|| !input[0].All(ch => char.IsDigit(ch))||!input[1].All(ch => char.IsDigit(ch)))
            {
                throw new ArgumentException("Invalid song length.");
            }
            
            int minutes = int.Parse(input[0]);
            this.Minutes = minutes;
            int seconds = int.Parse(input[1]);
            this.Seconds = seconds;
            this.Length = this.Minutes * 60 + this.Seconds;
        }
    }
}
