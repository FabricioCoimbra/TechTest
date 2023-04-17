using System.ComponentModel.DataAnnotations;

namespace TechTest.Model
{
    public class TeamScoresWithList
    {
        //I Prefer List<int>, but the question specify array.
        /// <summary>
        /// Goals of Team A
        /// </summary>
        /// <example>[1, 4, 2, 4]</example>
        [Required]
        public List<int> TeamA { get; set; } = new();
        /// <summary>
        /// Goals of Team B
        /// </summary>
        /// <example>[3, 5]</example>
        [Required]
        public List<int> TeamB { get; set; } = new();
    }
}
