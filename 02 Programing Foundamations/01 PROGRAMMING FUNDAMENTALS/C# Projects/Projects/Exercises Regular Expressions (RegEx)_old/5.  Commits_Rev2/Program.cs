using System.Linq;

namespace _13.Regex_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class Exercises
    {
        static void Main()
        {
            // Task 5
            Commits();
        }

        private static void Commits()
        {
            Dictionary<string, Dictionary<string, List<Commit>>> usersAndRepos = new Dictionary<string, Dictionary<string, List<Commit>>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "git push")
                    break;

                string pattern = "https:\\/\\/github\\.com\\/(?<user>[A-Za-z0-9-]+)\\/(?<repo>[A-Z-a-z-_]+)\\/commit\\/(?<hash>[0-9a-f]{40}),(?<message>[^\\r\\n|\\r|\\n]+),(?<additions>[0-9]+),(?<deletions>[0-9]+)";
                Regex regex = new Regex(pattern);

                if (regex.IsMatch(input))
                {
                    Match match = regex.Match(input);
                    string user = match.Groups["user"].Value;
                    string repo = match.Groups["repo"].Value;
                    string hash = match.Groups["hash"].Value;
                    string message = match.Groups["message"].Value;
                    double additions = double.Parse(match.Groups["additions"].Value);
                    double deletions = double.Parse(match.Groups["deletions"].Value);

                    if (!usersAndRepos.ContainsKey(user))
                    {
                        usersAndRepos[user] = new Dictionary<string, List<Commit>>();
                    }

                    if (!usersAndRepos[user].ContainsKey(repo))
                    {
                        usersAndRepos[user][repo] = new List<Commit>();
                    }

                    Commit commit = new Commit
                    {
                        Message = message,
                        Hash = hash,
                        Additions = additions,
                        Deletions = deletions
                    };

                    usersAndRepos[user][repo].Add(commit);
                }
            }

            foreach (KeyValuePair<string, Dictionary<string, List<Commit>>> user in usersAndRepos.OrderBy(u => u.Key))
            {
                Console.WriteLine($"{user.Key}:");

                foreach (KeyValuePair<string, List<Commit>> repo in user.Value.OrderBy(r => r.Key))
                {
                    Console.WriteLine($"  {repo.Key}:");

                    foreach (Commit commit in repo.Value)
                    {
                        Console.WriteLine($"    commit {commit.Hash}: {commit.Message} ({commit.Additions} additions, {commit.Deletions} deletions)");
                    }

                    Console.WriteLine($"    Total: {repo.Value.Sum(commit => commit.Additions)} additions, {repo.Value.Sum(commit => commit.Deletions)} deletions");
                }
            }

            //usersAndRepos
            //    .OrderBy(u => u.Key)
            //    .ToList()
            //    .ForEach(user => user.Value.OrderBy(r => r.Key).ToList()
            //    .ForEach(repo =>
            //        Console.WriteLine($"{user.Key}:\n  " +
            //                          $"{repo.Key}:\n    " +
            //                          $"commit {string.Join("\n    commit ", repo.Value)}\n    " +
            //                          $"Total: {repo.Value.Sum(c => c.Additions)} additions, {repo.Value.Sum(c => c.Deletions)} deletions")));
        }
    }

    class Commit
    {
        public string Hash { get; set; }
        public string Message { get; set; }
        public double Additions { get; set; }
        public double Deletions { get; set; }

        public override string ToString()
        {
            return string.Format($"{this.Hash}: {this.Message} ({this.Additions} additions, {this.Deletions} deletions)");
        }
    }
}