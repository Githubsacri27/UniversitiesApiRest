using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversitiesApp.Domain.Models.Validators
{
    public class UniversityModelValidator
    {
        public static bool IsValidStringForSearch(string str)
            => str != null && str.Replace("\t", "").Trim().Length > 0;
    }
}
