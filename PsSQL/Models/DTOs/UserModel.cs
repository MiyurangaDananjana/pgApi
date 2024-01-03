using Newtonsoft.Json;

namespace PsSQL.Models.DTOs
{
    public class UserModel
    {
        [JsonProperty("UserName")]
        public string? UserName { get; set; }

        [JsonProperty("UserPassword")]
        public string? UserPassword { get; set; }

        [JsonProperty("CenterId")]
        public int CenterId { get; set; }
    }
}
