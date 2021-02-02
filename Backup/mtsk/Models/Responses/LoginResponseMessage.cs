using System;
using Newtonsoft.Json;

namespace mtsk.Models.Responses
{
    public class LoginResponseMessage
    {
        [JsonProperty("success")]
        public int Success { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
