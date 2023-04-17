using TechTest.Model;

namespace TechTest.Service
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
        //Used only on benchmark
        public List<int> ComputeTotalTeamScores(TeamScoresWithList teamScores)
        {
            var result = new List<int>();
            foreach (var actualScoreTeamB in teamScores.TeamB)
            {
                var scoresBiggerThanA = teamScores.TeamA.Where(x => actualScoreTeamB >= x).Count();
                result.Add(scoresBiggerThanA);
            }
            return result;
        }
        //Used only on benchmark
        public List<int> ComputeTotalOptimizedWithLinq(TeamScoresWithList teamScores) =>
            teamScores.TeamB
                .Select(actualScoreTeamB => 
                    teamScores.TeamA.Where(x => actualScoreTeamB >= x).Count())
                .ToList();
        //Used only on benchmark
        public List<int> ComputeTotalOptimizedWithForeach(TeamScoresWithList teamScores)
        {
            var result = new List<int>();
            int count;
            foreach (var actualScoreTeamB in teamScores.TeamB)
            {
                count = 0;
                foreach (var scoreTeamA in teamScores.TeamA)
                {
                    if (actualScoreTeamB >= scoreTeamA)
                    {
                        count++;
                    }
                }
                result.Add(count);
            }

            return result;
        }
    }
}
