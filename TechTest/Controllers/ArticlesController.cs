using Microsoft.AspNetCore.Mvc;
using TechTest.Model;
using TechTest.service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
