using Microsoft.AspNetCore.Mvc;
using TechTest.Model;
using TechTest.Service;

namespace TechTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamScoresController : ControllerBase
    {
        private readonly ITeamScoresService teamScoresService;
        private readonly ILogger<TeamScoresController> logger;

        public TeamScoresController(ITeamScoresService teamScoresService, ILogger<TeamScoresController> logger)
        {
            this.teamScoresService = teamScoresService;
            this.logger = logger;
        }
        // GET: api/<TeamScoresController>/ComputeTotalTeamScores
        /// <summary>
        /// Compute the total number of matches of team A where team A has scored less  than or equal to the number of goals scored by team B in that match
        /// </summary>
        /// <param name="teamScores">The number of goals with TeamA and TeamB</param>
        /// <returns></returns>
        [HttpPost("ComputeTotalTeamScores")]
        public ActionResult<int[]> ComputeTotalTeamScores([FromBody] TeamScores teamScores)
        {
            try
            {
                var result = teamScoresService.ComputeTotalTeamScores(teamScores);

                return Ok(result);
            }
            catch (Exception e)
            {
                var errorMessage = $"Error on ComputeTotalTeamScores {e.Message} ";
                logger.LogError(errorMessage);
                return BadRequest(errorMessage);
            }
        }
    }
}
