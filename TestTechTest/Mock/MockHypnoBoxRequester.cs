using TechTest.Model;
using TechTest.Service;

namespace TestTechTest.Mock
{
    internal class MockHypnoBoxRequester : IHypnoBoxRequester
    {
        public ValueTask<List<Article>> GetArticlesFromAPI()
        {
            return ValueTask.FromResult(new List<Article>()
            {
                new()
                {
                    url = "Invalid article"
                },
                new()
                {
                    num_comments = 1,
                    story_title = "www Second article"
                },
                new()
                {
                    num_comments = 1,
                    title = "ZZZ First article"
                },
                new()
                {
                    num_comments = 0,
                    story_title = "Third article"
                },
            });
        }
    }
}
