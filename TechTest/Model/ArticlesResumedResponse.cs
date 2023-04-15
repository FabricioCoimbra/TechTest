using System.ComponentModel.DataAnnotations;

namespace TechTest.Model
{
    public class ArticlesResumedResponse
    {
        /// <summary>
        /// Count of comments, zero when null
        /// </summary>
        [Required]
        public int CountComments { get; set; }
        /// <summary>
        /// The title or the StoryTitle if title is null
        /// </summary>
        [Required]
        public string Title { get; set; } = string.Empty;
    }
}
