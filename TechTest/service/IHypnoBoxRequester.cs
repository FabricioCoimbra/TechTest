using TechTest.Model;

namespace TechTest.service
{
    public interface IHypnoBoxRequester
    {
        Task<List<Article>> GetArticlesFromAPI();
    }
}