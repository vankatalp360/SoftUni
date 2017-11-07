using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _9.Teamwork_projects
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> TeamsGroup = AddTeamsInGroup();
            AddTeamsMembers(TeamsGroup);
            PrintTeams(TeamsGroup);
        }

        private static void PrintTeams(Dictionary<string, Team> teamsGroup)
        {
            foreach (var team in teamsGroup.Values.Where(x => x.Members.Count > 0).OrderByDescending(x => x.Members.Count()).ThenBy(x => x.TeamName))
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.Creator}");
                foreach (var member in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }

            }
            Console.WriteLine($"Teams to disband:");

            foreach (var team in teamsGroup.Values.Where(x => x.Members.Count == 0).OrderBy(x => x.TeamName))
            {
                Console.WriteLine(team.TeamName);
            }

        }

        private static void AddTeamsMembers(Dictionary<string, Team> teamsGroup)
        {
            string input = Console.ReadLine();
            string pattern = @"(.*)->(.*)";
            Regex regex = new Regex(pattern);

            while (input != "end of assignment")
            {
                Match match = regex.Match(input);
                if (match.Groups.Count != 3)
                {
                    input = Console.ReadLine();
                    continue;
                }
                string member = match.Groups[1].ToString();
                string teamName = match.Groups[2].ToString();
                bool exist = false;
                foreach (var team in teamsGroup.Values)
                {
                    if (team.TeamName == teamName)
                    {
                        exist = true;
                        break;
                    }
                }
                if (exist == false)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    input = Console.ReadLine();
                    continue;
                }
                bool membered = false;
                if (teamsGroup.ContainsKey(member))
                {
                    membered = true;
                }
                else
                {
                    foreach (var team in teamsGroup.Values)
                    {
                        if (team.Members.Contains(member))
                        {
                            membered = true;
                            break;
                        }
                    }
                }
                if (membered == true)
                {
                    Console.WriteLine($"Member {member} cannot join team {teamName}!");
                    input = Console.ReadLine();
                    continue;
                }
                string teamCreator = null;
                foreach (var team in teamsGroup.Values)
                {
                    if (team.TeamName == teamName)
                    {
                        teamCreator = team.Creator;
                        break;
                    }
                }
                if (!teamsGroup[teamCreator].Members.Contains(member))
                    teamsGroup[teamCreator].Members.Add(member);
                input = Console.ReadLine();
            }
        }

        private static Dictionary<string, Team> AddTeamsInGroup()
        {
            Dictionary<string, Team> TeamsGroup = new Dictionary<string, Team>();
            int numberOfTeams = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberOfTeams; i++)
            {
                string[] inputToArr = Console.ReadLine().Split('-');
                string nameCreator = inputToArr[0];
                string teamName = inputToArr[1];
                bool exist = false;
                foreach (var team in TeamsGroup.Values)
                {
                    if (team.TeamName == teamName)
                    {
                        Console.WriteLine($"Team {teamName} was already created!");
                        exist = true;
                        continue;
                    }
                }
                if (exist) continue;
                if (TeamsGroup.ContainsKey(nameCreator))
                {
                    if (TeamsGroup[nameCreator].TeamName != teamName)
                    {
                        Console.WriteLine($"{nameCreator} cannot create another team!");
                    }
                    continue;
                }
                else
                {
                    TeamsGroup.Add(nameCreator, new Team());
                    TeamsGroup[nameCreator].TeamName = teamName;
                    TeamsGroup[nameCreator].Creator = nameCreator;
                    TeamsGroup[nameCreator].Members = new List<string>();
                    Console.WriteLine($"Team {teamName} has been created by {nameCreator}!");
                }
            }
            return TeamsGroup;
        }
    }
    class Team
    {
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }
}
