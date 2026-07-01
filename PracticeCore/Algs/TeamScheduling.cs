using System;
using System.Collections.Generic;
using System.Text;

namespace Algs
{
    //Given 8 football teams, come up with a schedule such that every team plays against every other team one a balanced shedule.

    public static class TeamScheduling
    {
        public static IEnumerable<Match> GetMatchesFor(IList<Team> teams)
        {
            IList<Match> matches = new List<Match>();
            DateTime startDate = DateTime.Now;
            while (teams.Any(t => t.Matches.Count < teams.Count - 1))
            {
                Match nextMatch = teams.GetNextMatch(ref startDate);
                matches.Add(nextMatch);
            }
            return matches;
        }

        private static Match? GetNextMatch(this IList<Team> teams, ref DateTime nextDateTime)
        {
            if (!teams.Any(t => t.Matches.Count < teams.Count - 1)) return null;

            IEnumerable<Team> teamsAscByLeastGames = teams.OrderBy(t => t.Matches.Count).ToList();

            Match nextMatch = new Match
            {
                Team1 = teamsAscByLeastGames.FirstOrDefault(),
                Team2 = teamsAscByLeastGames.FirstOrDefault().GetNextCompetitor(teamsAscByLeastGames),
                Date = nextDateTime
            };

            teamsAscByLeastGames.FirstOrDefault().Matches.Add(nextMatch);
            teamsAscByLeastGames.FirstOrDefault().GetNextCompetitor(teamsAscByLeastGames).Matches.Add(nextMatch);

            nextDateTime = nextDateTime.AddDays(1);
            return nextMatch;
        }

        private static bool HasPlayedWith(this Team team, Team otherTeam) => team.Matches.Any(m => m.Team1.Id == otherTeam.Id || m.Team2.Id == otherTeam.Id);

        private static Team GetNextCompetitor(this Team team, IEnumerable<Team> teams) => teams.FirstOrDefault(t => !t.Equals(team) && !t.HasPlayedWith(team));
    }

    public class Team
    {
        public int Id { get; }

        public IList<Match> Matches { get; set; } = new List<Match>();

        public Team(int id)
        {
            Id = id;
        }

        public override bool Equals(object? obj) => obj is Team team && team.Equals(this);

        private bool Equals(Team other)
        {
            return this.GetHashCode() == other.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }

    public class Match
    {
        public required Team Team1 { get; set; }

        public required Team Team2 { get; set; }

        public DateTime Date { get; set; }
    }
}
