using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversitiesApp.Infrastructure.Contracts.Entities
{
    public class UniversityPage
    {
        public UniversityPage()
        {
            University = new HashSet<University>();
        }

        [Key]
        public int Id { get; set; }
        public int Count { get; set; }

        [InverseProperty("UniversityPage")]
        public virtual ICollection<University> University { get; set; }
    }
}
