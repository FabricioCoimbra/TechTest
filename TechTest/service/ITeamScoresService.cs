using TechTest.Model;

namespace TechTest.service
{
    public interface ITeamScoresService
    {
        int[] ComputeTotalTeamScores(TeamScores teamScores);
    }
}