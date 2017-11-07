using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _5.Commits
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"https:\/\/github\.com\/(?<user>[A-Za-z0-9-]+)\/(?<repo>[A-Za-z-_]+)\/commit\/(?<hash>[0-9a-f]{40})\,(?<message>[^(\n)|(\r)|(\r\n)]+)\,(?<additions>[0-9]+)\,(?<deletions>[0-9]+)";
            SortedDictionary<string, SortedDictionary<string, List<Commit>>> report = new SortedDictionary<string, SortedDictionary<string, List<Commit>>>();
            string input = Console.ReadLine();
            while (input != "git push")
            {
                if (Regex.IsMatch(input, pattern))
                {
                    Match userInfo = Regex.Match(input, pattern);
                    string user = userInfo.Groups["user"].Value;
                    string repo = userInfo.Groups["repo"].Value;
                    Commit commit = new Commit();
                    commit.Hash = userInfo.Groups["hash"].Value;
                    commit.Message = userInfo.Groups["message"].Value;
                    commit.Additions = int.Parse(userInfo.Groups["additions"].Value);
                    commit.Deletions = int.Parse(userInfo.Groups["deletions"].Value);

                    if (!report.ContainsKey(user))
                    {
                        report[user] = new SortedDictionary<string, List<Commit>>();
                    }
                    if (!report[user].ContainsKey(repo))
                    {
                        report[user][repo] = new List<Commit>();
                    }
                    report[user][repo].Add(commit);
                }
                input = Console.ReadLine();
            }

            foreach (var user in report)
            {
                Console.WriteLine($"{user.Key}:");
                foreach (var repo in user.Value)
                {
                    Console.WriteLine($"  {repo.Key}:");
                    foreach (Commit currentCommit in repo.Value)
                    {
                        Console.WriteLine($"    commit {currentCommit.Hash}: {currentCommit.Message} ({currentCommit.Additions} additions, {currentCommit.Deletions} deletions)");
                    }
                    Console.WriteLine($"    Total: {repo.Value.Sum(x=>x.Additions)} additions, {repo.Value.Sum(x => x.Deletions)} deletions");
                }
                
            }
        }
    }
    class Commit
    {
        public string Hash { get; set; }
        public string Message { get; set; }
        public int Additions { get; set; }
        public int Deletions { get; set; }
    }
}