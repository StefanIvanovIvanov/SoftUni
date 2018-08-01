using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace JsonProcessing
{
    public class Person
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastNAme { get; set; }
        [JsonProperty("jobTitle")]
        public string JobTitle { get; set; }
    }
}
