using Newtonsoft.Json;

namespace PsSQL.Models.DTOs
{
    public class UserModel
    {
        [JsonProperty("UserName")]
        public string? UserName { get; set; }

        [JsonProperty("UserPassword")]
        public string? UserPassword { get; set; }


        [JsonProperty("UserStatus")]
        public int UserStatus { get; set; }

        [JsonProperty("CenterId")]
        public int CenterId { get; set; }



        [JsonProperty("LastLoginDateTime")]
        public DateTime LastLoginDateTime
        {
            get { return _lastLoginDateTime; }
            set
            {
                _lastLoginDateTime = DateTime.Now;
            }
        }
        private DateTime _lastLoginDateTime;


    }
}
