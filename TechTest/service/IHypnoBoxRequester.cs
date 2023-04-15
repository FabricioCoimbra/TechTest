using TechTest.Model;

namespace TechTest.Service
{
    public interface IHypnoBoxRequester
    {
        ValueTask<List<Article>> GetArticlesFromAPI();
    }
}