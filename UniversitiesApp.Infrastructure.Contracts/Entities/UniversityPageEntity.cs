using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UniversitiesApp.Infrastructure.Contracts.Entities
{
    public class UniversityPageEntity
    {
        [JsonPropertyName("Property1")]
        public UniversityEntity[] Universities { get; set; }
    }
}
