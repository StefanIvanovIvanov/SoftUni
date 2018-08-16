using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SoftJail.DataProcessor.ExportDto
{
   public class OfficersDto
    {
        [JsonProperty("OfficerName")]
        public string OfficerName { get; set; }

        [JsonProperty("Department")]
        public string Department { get; set; }
    }
}
