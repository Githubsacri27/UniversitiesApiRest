using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using UniversitiesApp.XCutting.Enums;

namespace UniversitiesApp.Library.Contracts.DTOs
{
    public class UniversityNameWebListDto
    {
        public string Name { get; set; }
        public List<string> Webs { get; set; }
    }
}
