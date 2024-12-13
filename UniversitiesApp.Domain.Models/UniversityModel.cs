using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversitiesApp.Domain.Models
{
    public class UniversityModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string? AlphaTwoCode { get; set; }
        public List<string> Domains { get; set; }
        public List<string> WebPages { get; set; }
    }
}
