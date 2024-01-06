using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PsSQL.Models.Entities
{
    public class Books
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public string? Authors { get; set; }
        public string? Categories { get; set; }
        public string? Thumbnail { get; set; }
        public string? Description { get; set; }
        public int PublishedYear { get; set; }
        public double AverageRating { get; set; }
        public int NumPages { get; set; }
        public int RatingsCount { get; set; }
    }

}
