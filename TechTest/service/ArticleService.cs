using TechTest.Model;

namespace TechTest.Service
{
    public class ArticleService : IArticleService
    {
        private readonly IHypnoBoxRequester requester;

        public ArticleService(IHypnoBoxRequester requester)
        {
            this.requester = requester;
        }
        public async Task<List<ArticlesResumedResponse>> GetMostCommentedArticles(int limit)
        {

            List<Article> articles = await requester.GetArticlesFromAPI();
            //TODO Verify if an article without title, but have comments, can be returned
            articles.RemoveAll(x => x.num_comments is null &&
                string.IsNullOrEmpty(x.title) &&
                string.IsNullOrEmpty(x.story_title));

            articles = articles
                .OrderByDescending(x => x.num_comments ?? 0)
                .ThenByDescending(x => x.title ?? x.story_title)
                .ToList();

            return articles
                .Take(limit)
                .Select(x => new ArticlesResumedResponse()
                {
                    CountComments = x.num_comments ?? 0,
                    Title = x.title ?? x.story_title ?? ""
                }).ToList();
        }
    }
}
