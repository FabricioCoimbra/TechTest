using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using TechTest.Model;
using TechTest.Service;

namespace BenchmarkTechTest
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.NativeAot70)]  
    [SimpleJob(RuntimeMoniker.Net70)]
    public class TeamScoresBenchmark
    {
        [Benchmark]
        public void CompareWithArray()
        {
            TeamScoresService service = new();
            TeamScores teamScores = new()
            {
                TeamA = new int[4] { 1, 4, 2, 4 },
                TeamB = new int[5] { 2, 10, 5, 4, 8 },
            };
            var result = service.ComputeTotalTeamScores(teamScores);
        }

        [Benchmark]
        public void CompareWithLists()
        {
            TeamScoresService service = new();
            TeamScoresWithList teamScores = new()
            {
                TeamA = new() { 1, 4, 2, 4 },
                TeamB = new() { 2, 10, 5, 4, 8 },
            };
            var result = service.ComputeTotalTeamScores(teamScores);
        }

        [Benchmark]
        public void CompareWithListsAndLinq()
        {
            TeamScoresService service = new();
            TeamScoresWithList teamScores = new()
            {
                TeamA = new() { 1, 4, 2, 4 },
                TeamB = new() { 2, 10, 5, 4, 8 },
            };
            var result = service.ComputeTotalOptimizedWithLinq(teamScores);
        }

        [Benchmark]
        public void CompareWithListsAndForeach()
        {
            TeamScoresService service = new();
            TeamScoresWithList teamScores = new()
            {
                TeamA = new() { 1, 4, 2, 4 },
                TeamB = new() { 2, 10, 5, 4, 8 },
            };
            var result = service.ComputeTotalOptimizedWithForeach(teamScores);
        }
    }
}
