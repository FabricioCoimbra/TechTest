using Microsoft.AspNetCore.Mvc;
using TechTest.Model;
using TechTest.Service;

namespace TechTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService articleService;
        private readonly ILogger<ArticlesController> logger;

        public ArticlesController(IArticleService articleService, ILogger<ArticlesController> logger)
        {
            this.articleService = articleService;
            this.logger = logger;
        }
        // GET: api/<ArticlesController>/MostCommented/{limit}
        /// <summary>
        /// return the list of mos commented articles, ordered by comments and title/story_title
        /// </summary>
        /// <param name="limit">Limit result count</param>
        /// <returns></returns>
        [HttpGet("MostCommented/{limit}")]
        public async Task<ActionResult<List<ArticlesResumedResponse>>> GetMostCommentedArticles([FromRoute] int limit)
        {
            try
            {
                var result = await articleService.GetMostCommentedArticles(limit);

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
