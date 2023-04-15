using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;
using TechTest.Model;

namespace TechTest.Service
{
    public class HypnoBoxRequester : IHypnoBoxRequester
    {
        private readonly IMemoryCache cache;
        private readonly IHttpClientFactory httpClientFactory;

        public HypnoBoxRequester(IMemoryCache cache, IHttpClientFactory httpClientFactory)
        {
            this.cache = cache;
            this.httpClientFactory = httpClientFactory;
        }
        public async ValueTask<List<Article>> GetArticlesFromAPI()
        {
            return await cache.GetOrCreateAsync("Foo", async key =>
            {
                List<Article> result = new();
                var client = httpClientFactory.CreateClient("HypnoBox");
                int totalPages = 0;
                int page = 1;
                do
                {
                    var articlesJson = await client.GetStringAsync($"?page={page}");

                    var articles = JsonSerializer.Deserialize<ArticelResponse>(articlesJson);
                    page++;
                    totalPages = articles?.total_pages ?? 0;

                    result.AddRange(articles?.data ?? new());

                } while (page <= totalPages);

                return result;
            }) ?? new();
        }
    }
}
