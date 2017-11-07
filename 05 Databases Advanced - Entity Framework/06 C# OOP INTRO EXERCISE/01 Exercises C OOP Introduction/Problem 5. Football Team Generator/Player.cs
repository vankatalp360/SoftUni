namespace Problem_5.Football_Team_Generator
{
    using System;
    using System.Linq;

    public class Player
    {
        private string name;
        private Stats stats;

        internal Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public Stats Stats
        {
            get
            {
                return this.stats;
            }
            internal set
            {
                this.stats = value;
            }
        }
        
        internal double CalculatePlayerSkillLevel()
        {
            int[] stats = { this.stats.Endurance, this.stats.Sprint, this.stats.Dribble, this.stats.Passing, this.stats.Shooting };
            return stats.Average();
        }
    }
}
