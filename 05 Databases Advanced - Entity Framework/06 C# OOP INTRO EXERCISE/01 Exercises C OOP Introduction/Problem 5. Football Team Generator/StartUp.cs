namespace Problem_5.Football_Team_Generator
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            while(true)
            {
                string[] commands = Console.ReadLine().Split(';');
                if (commands[0].Equals("END")) break;
                try
                {
                    switch (commands[0])
                    {
                        case "Team":
                            AddNewTeam(teams, commands);
                            break;
                        case "Add":
                            AddPlayerInTeam(teams, commands);
                            break;
                        case "Remove":
                            RemovePlayerFromTeam(teams, commands);
                            break;
                        case "Rating":
                            RateTeam(teams, commands);
                            break;
                    }
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        private static void RateTeam(List<Team> teams, string[] commands)
        {
            string teamName = commands[1];
            Team member = FindTeam(teams, teamName);
            Console.WriteLine(member);
        }

        private static Team FindTeam(List<Team> teams, string teamName)
        {
            Team member = teams.Find(x => x.Name == teamName);
            if (member == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            return member;
        }

        private static void RemovePlayerFromTeam(List<Team> teams, string[] commands)
        {
            string teamName = commands[1];
            Team member = FindTeam(teams, teamName);

            string playerName = commands[2];
            member.RemovePlayer(playerName);
        }

        private static void AddPlayerInTeam(List<Team> teams, string[] commands)
        {
            string teamName = commands[1];
            Team member = FindTeam(teams, teamName);

            string playerName = commands[2];
            int endurance = int.Parse(commands[3]);
            int sprint = int.Parse(commands[4]);
            int dribble = int.Parse(commands[5]);
            int passing = int.Parse(commands[6]);
            int shooting = int.Parse(commands[7]);
            Stats playerStats = new Stats(endurance, sprint, dribble, passing, shooting);
            Player newPlayer = new Player(playerName, playerStats);
            member.AddPlayer(newPlayer);
        }

        private static void AddNewTeam(List<Team> teams, string[] commands)
        {
            string teamName = commands[1];
            Team member = teams.Find(x => x.Name == teamName);

            if (member==null)
            {
                Team newTeam = new Team(teamName);
                teams.Add(newTeam);
            }           
        }
    }
}
