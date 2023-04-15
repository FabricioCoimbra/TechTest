using TechTest.Model;

namespace TechTest.Service
{
    public interface ITeamScoresService
    {
        int[] ComputeTotalTeamScores(TeamScores teamScores);
    }
}