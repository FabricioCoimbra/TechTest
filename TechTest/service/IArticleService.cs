using TechTest.Model;

namespace TechTest.service
{
    public interface IArticleService
    {
        Task<List<ArticlesResumedResponse>> GetMostCommentedArticles(int limit);
    }
}