using TechTest.Model;

namespace TechTest.service
{
    public class TeamScoresService : ITeamScoresService
    {
        public int[] ComputeTotalTeamScores(TeamScores teamScores)
        {
            var result = new List<int>();
            foreach (var actualScoreTeamB in teamScores.TeamB)
            {
                var scoresBiggerThanA = teamScores.TeamA.Where(x => actualScoreTeamB >= x).Count();
                result.Add(scoresBiggerThanA);
            }
            return result.ToArray();
        }
    }
}
