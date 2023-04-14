namespace TechTest.Model
{
    //DTO
    public class TeamScores
    {
        //I Prefer List<int>, but the question specify array.
        public int[] TeamA { get; set; } = new int[3] { 1, 2, 3 };
        public int[] TeamB { get; set; } = new int[2] { 2, 4 };
    }
}
