using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _09.FootballStandings
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyWord = Regex.Escape(Console.ReadLine());

            var teamRegex = new Regex($@"^.*(?:{keyWord})(?<team1>[A-Za-z]*)(?:{keyWord}).*(?:{keyWord})(?<team2>[A-Za-z]*)(?:{keyWord})");
            var scoreRegex = new Regex(@"(?<result>\d+\:\d+)");

            string line = Console.ReadLine();

            List<Team> teams = new List<Team>();

            while (line != "final")
            {
                var teamMatches = teamRegex.Match(line);

                string homeTeam = new string(teamMatches.Groups["team1"].Value.ToCharArray().Reverse().ToArray()).ToUpper();
                string awayTeam = new string(teamMatches.Groups["team2"].Value.ToCharArray().Reverse().ToArray()).ToUpper();

                var score = scoreRegex.Match(line).Groups["result"].Value;
                var scoreTokens = score.Split(':').ToArray();
                var homeTeamGoals = long.Parse(scoreTokens[0]);
                var awayTeamGoals = long.Parse(scoreTokens[1]);

                var homeTeamPoints = 0;
                var awayTeamPoints = 0;
                DistributePoints(homeTeamGoals, awayTeamGoals, ref homeTeamPoints, ref awayTeamPoints);

                if (teams.Any(x => x.TeamName == homeTeam))
                {
                    var existingHomeTeam = teams.First(x => x.TeamName == homeTeam);
                    existingHomeTeam.Points += homeTeamPoints;
                    existingHomeTeam.ScoredGoals += homeTeamGoals;
                }
                else
                {
                    var team = new Team(homeTeam, homeTeamPoints, homeTeamGoals);
                    teams.Add(team);
                }

                if (teams.Any(x => x.TeamName == awayTeam))
                {
                    var existingAwayTeam = teams.First(x => x.TeamName == awayTeam);
                    existingAwayTeam.Points += awayTeamPoints;
                    existingAwayTeam.ScoredGoals += awayTeamGoals;
                }
                else
                {
                    var team = new Team(awayTeam, awayTeamPoints, awayTeamGoals);
                    teams.Add(team);
                }

                line = Console.ReadLine();
            }
            Console.WriteLine("League standings:");
            int cnt = 1;
            foreach (var team in teams.OrderByDescending(x => x.Points).ThenBy(x => x.TeamName))
            {
                Console.WriteLine($"{cnt}. {team.TeamName} {team.Points}");
                cnt++;
            }
            Console.WriteLine("Top 3 scored goals:");
            foreach (var team in teams.OrderByDescending(x => x.ScoredGoals).ThenBy(x => x.TeamName).Take(3))
            {
                Console.WriteLine($"- {team.TeamName} -> {team.ScoredGoals}");
            }
        }

        private static void DistributePoints(long homeTeamGoals, long awayTeamGoals, ref int homeTeamPoints, ref int awayTeamPoints)
        {
            if (homeTeamGoals > awayTeamGoals)
            {
                homeTeamPoints = 3;
            }
            else if (awayTeamGoals > homeTeamGoals)
            {
                awayTeamPoints = 3;
            }
            else
            {
                homeTeamPoints = 1;
                awayTeamPoints = 1;
            }
        }
    }

    public class Team
    {
        public Team(string teamName, int points, long scoredGoals)
        {
            TeamName = teamName;
            Points = points;
            ScoredGoals = scoredGoals;
        }

        public string TeamName { get; set; }

        public int Points { get; set; }

        public long ScoredGoals { get; set; }
    }
}
    
