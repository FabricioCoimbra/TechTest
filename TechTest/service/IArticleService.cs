using TechTest.Model;

namespace TechTest.Service
{
    public interface IArticleService
    {
        Task<List<ArticlesResumedResponse>> GetMostCommentedArticles(int limit);
    }
}