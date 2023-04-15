using System.ComponentModel.DataAnnotations;

namespace TechTest.Model
{
    //DTO
    public class TeamScores
    {
        //I Prefer List<int>, but the question specify array.
        /// <summary>
        /// Goals of Team A
        /// </summary>
        /// <example>[1, 4, 2, 4]</example>
        [Required]
        public int[] TeamA { get; set; } = new int[0];
        /// <summary>
        /// Goals of Team B
        /// </summary>
        /// <example>[3, 5]</example>
        [Required]
        public int[] TeamB { get; set; } = new int[0];
    }
}
