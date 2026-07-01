using FluentAssertions;
using System.Collections.ObjectModel;

namespace Algs.Tests
{
    public class TeamSchedulingTests
    {
        [Test]
        public void TeamScheduling_GetsTheCorrectSchedule()
        {
            // Arrange
            Collection<Team> teams = new Collection<Team> { new Team(1), new Team(2), new Team(3), new Team(4), new Team(5), new Team(6), new Team(7) };
            string expectedMatchIds = "12 34 56 71 23 45 67 13 24 57 61 25 36 47 14 26 35 72 15 37 46";

            // Act
            IEnumerable<Match> actual = TeamScheduling.GetMatchesFor(teams);

            // Assert
            expectedMatchIds.Should().BeEquivalentTo(string.Join(" ", actual.Select(m => $"{m.Team1.Id}{m.Team2.Id}")));
        }
    }
}
