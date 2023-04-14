using System.Text.Json;
using TechTest.Model;

namespace TechTest.service
{
    public class HypnoBoxRequester : IHypnoBoxRequester
    {
        public async Task<List<Article>> GetArticlesFromAPI()
        {
            List<Article> result = new();
            var client = new HttpClient();
            int totalPages = 0;
            int page = 1;
            do
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, $"http://your-url-here/teste/api/articles?page={page}");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var articlesJson = await response.Content.ReadAsStringAsync();

                var articles = JsonSerializer.Deserialize<ArticelResponse>(articlesJson);
                page++;
                totalPages = articles?.total_pages ?? 0;

                result.AddRange(articles?.data ?? new());

            } while (page <= totalPages);

            return result;
        }
    }
}
