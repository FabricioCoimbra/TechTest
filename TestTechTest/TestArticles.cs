using TechTest.Service;
using TestTechTest.Mock;

namespace TestTechTest
{
    public class TestArticles
    {
        private readonly ArticleService service;
        public TestArticles()
        {
            //setup
            var requester = new MockHypnoBoxRequester();
            service = new ArticleService(requester);
        }

        [Fact]
        public async Task TestNotNullWhenIsZero()
        {
            // Arrange

            //Act
            var result = await service.GetMostCommentedArticles(0);

            //Test
            Assert.NotNull(result);
        }

        [Fact]
        public async Task TestOrderOfArticles()
        {
            // Arrange

            //Act
            var result = await service.GetMostCommentedArticles(3);

            //Test
            Assert.Equal("ZZZ First article", result?.First()?.Title);
            Assert.Equal("Third article", result?.Last()?.Title);
        }

        [Fact]
        public async Task TestIfIsRemovedNullTitle()
        {
            // Arrange

            //Act
            var result = await service.GetMostCommentedArticles(50);

            //Test
            Assert.Null(result?.FirstOrDefault(x => string.IsNullOrEmpty(x.Title)));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(0)]
        public async Task TestLimits(int limit)
        {
            // Arrange

            //Act
            var result = await service.GetMostCommentedArticles(limit);

            //Test
            Assert.Equal(limit, result.Count);
        }
    }
}