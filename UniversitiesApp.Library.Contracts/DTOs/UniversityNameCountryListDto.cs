using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniversitiesApp.XCutting.Enums;

namespace UniversitiesApp.Library.Contracts.DTOs
{
    public class UniversityNameCountryListDto
    {
        [IgnoreDataMember]
        [JsonIgnore]
        public bool HasErrors { get; set; }
        [IgnoreDataMember]
        [JsonIgnore]
        public UniversityEnumError Error { get; set; }
        [IgnoreDataMember]
        [JsonIgnore]
        public string? ErrorMsg { get; set; }
        public List<UniversityNameCountryDto>? Universities { get; set; }
    }
}
