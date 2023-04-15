using TechTest.Model;
using TechTest.Service;

namespace TestTechTest
{
    public class TeamScoresTest
    {
        [Theory]
        [InlineData(new int[1] { 1 }, new int[1] { 1 }, new int[1] { 1 })]
        [InlineData(new int[4] { 1, 4, 2, 4 }, new int[2] { 3, 5 }, new int[2] { 2, 4 })]
        [InlineData(new int[5] { 2, 10, 5, 4, 8 }, new int[4] { 3, 1, 7, 8 }, new int[4] { 1, 0, 3, 4 })]
        public void CompareTeamScoresTest(int[] teamA, int[] teamB, int[] ExpectedResult)
        {
            //Arrange
            TeamScoresService service = new();
            TeamScores teamScores = new()
            {
                TeamA = teamA,
                TeamB = teamB,
            };

            //Act
            var result = service.ComputeTotalTeamScores(teamScores);

            //Assert
            Assert.Equal(ExpectedResult, result);
        }
    }
}
