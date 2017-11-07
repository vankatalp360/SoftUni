using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5.Football_Team_Generator
{
    public class Team
    {
        private string name;
        private HashSet<Player> players;

        protected Team()
        {
            this.players = new HashSet<Player>();
        }

        public Team(string name)
            : this()
        {
            this.Name = name;
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

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player member = this.players.FirstOrDefault(x => x.Name == playerName);
            if (member == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }
            this.players.Remove(member);
        }

        private double CalculateTeamRating()
        {
            if(this.players.Count==0)
            {
                return 0;
            }
            double averageLevel = this.players.Average(x => x.CalculatePlayerSkillLevel());

            return Math.Round(averageLevel);
        }

        public override string ToString()
        {
            return $"{this.name} - {this.CalculateTeamRating()}";
        }
    }
}
