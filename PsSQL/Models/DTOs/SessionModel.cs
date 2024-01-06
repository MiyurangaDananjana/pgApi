namespace PsSQL.Models.DTOs
{
    public class SessionModel
    {
        public string? SessionId { get; set; }

        public DateTime? CreatedDate { get; set; } = default(DateTime?);

    }
}
