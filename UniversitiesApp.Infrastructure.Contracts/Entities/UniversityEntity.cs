using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UniversitiesApp.Infrastructure.Contracts.Entities
{
    public class UniversityEntity
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("alpha_two_code")]
        public string Alpha_two_code { get; set; }
        [JsonPropertyName("domains")]
        public string[] Domains { get; set; }
        [JsonPropertyName("stateprovince")]
        public string Stateprovince { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("web_pages")]
        public string[] Web_pages { get; set; }
    }
}
