using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitiesApp.Library.Contracts.DTOs;

namespace UniversitiesApp.Library.Contracts
{
    public interface IUniversityService
    {
        //Task<List<UniversityDto>> GetUniversityAsync();

        //Task<List<UniversityNamesDto>> GetUniversityByNamesAsync();

        public Task<UniversityMigrationDto> ExecuteMigrationFromAPI2DB();
        public UniversityNameCountryListDto GetNameAndCountryFromUniversities();
        public UniversityNameWebListListDto GetNameAndWebListFromUniversities(string name);





    }
}
