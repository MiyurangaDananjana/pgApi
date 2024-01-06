using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PsSQL.Models.Entities
{
    public class BooksData
    {
        [Key]
        public string? BookId { get; set; }
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public string? Authors { get; set; }
        public string? Categories { get; set; }
        public string? Thumbnail { get; set; }
        public string? Description { get; set; }
        public string? PublishedYear { get; set; }
        public string? AverageRating { get; set; }
        public string? NumPages { get; set; }
        public string? RatingsCount { get; set; }
    }


}

