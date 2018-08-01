using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace JsonProcessing
{
   public class User
    {
        [JsonProperty("user")]

        public string Username { get; set; }

        [JsonIgnore]

        public string Password { get; set; }
    }
}
