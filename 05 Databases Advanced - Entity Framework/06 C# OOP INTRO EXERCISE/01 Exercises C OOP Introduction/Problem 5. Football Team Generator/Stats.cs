namespace Problem_5.Football_Team_Generator
{
    using System;
    using System.Linq;

    public class Stats
    {
        private const int minValue = 0;
        private const int maxValue = 100;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        internal Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            internal set
            {
                if (value< minValue || value>maxValue)
                {
                    throw new ArgumentException($"Endurance should be between {minValue} and {maxValue}.");
                }

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            internal set
            {
                if (value < minValue || value>maxValue)
                {
                    throw new ArgumentException($"Sprint should be between {minValue} and {maxValue}.");
                }

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            internal set
            {
                if (value < minValue || value>maxValue)
                {
                    throw new ArgumentException($"Dribble should be between {minValue} and {maxValue}.");
                }

                this.dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return this.passing;
            }
            internal set
            {
                if (value < minValue || value>maxValue)
                {
                    throw new ArgumentException($"Passing should be between {minValue} and {maxValue}.");
                }

                this.passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            internal set
            {
                if (value < minValue || value>maxValue)
                {
                    throw new ArgumentException($"Shooting should be between {minValue} and {maxValue}.");
                }

                this.shooting = value;
            }
        }        
    }
}
