using System;
using Newtonsoft.Json;

namespace mtsk.Models.Requests
{
    public class LoginRequestMessage
    {
        [JsonProperty("userEmail")]
        public string userEmail { get; set; }
        [JsonProperty("userPassword")]
        public string userPassword { get; set; }
    }
}
