
using UniversitiesApp.Infrastructure.Contracts;
using UniversitiesApp.Library.Contracts;
using UniversitiesApp.Library.Contracts.DTOs;
using UniversitiesApp.XCutting.Enums;
using UniversitiesApp.Domain.Models.Validators;
using UniversitiesApp.Domain.Models;

namespace UniversitiesApp.Library.Impl
{
    public class UniversityService : IUniversityService
    {

        private readonly IUniversityRepository _universityRepository;

        public UniversityService(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }

        //public async Task<List<UniversityDto>> GetUniversityAsync()
        //{
        //    // Llamada al Repositorio: GetUniversityAsync llama al método del repositorio para obtener la lista de universidades.
        //    var universities = await _universityRepository.GetUniversityAsync();

        //    // Transformación de Entidades a DTO: Con Select, se crea una lista de UniversityDto, seleccionando solo los campos requeridos 
        //    return universities.Select(u => new UniversityDto
        //    {
        //        Name = u.Name,
        //        Alpha_two_code = u.Alpha_two_code,
        //        Domains = u.Domains,
        //        Stateprovince = u.Stateprovince,
        //        Country = u.Country,
        //        Web_pages = u.Web_pages,
        //    }).ToList();
        //}

        //public async Task<List<UniversityNamesDto>> GetUniversityByNamesAsync()
        //{
        //    var universitiesNames = await _universityRepository.GetUniversityByNamesAsync();
        //    return universitiesNames.Select(u => new UniversityNamesDto
        //    {
        //        Name = u.Name
        //    }).ToList();
        //}


        public async Task<UniversityMigrationDto> ExecuteMigrationFromAPI2DB()
        {
            UniversityMigrationDto dto = new();
            try
            {
                dto.MigratedUniversitiesCount = await _universityRepository.UniversityMigrationFromAPI2DB();
            }
            catch (Exception ex)
            {
                dto.HasErrors = true;
                if (ex is HttpRequestException)
                {
                    dto.Error = UniversityEnumError.UnableToReachEndpoint;
                    dto.ErrorMsg = $"Unable to reach endpoint: {ex.Message}";
                }
                else
                {
                    dto.Error = UniversityEnumError.UnexpectedError;
                    dto.ErrorMsg = $"Unexpected Error: {ex.Message}";
                }
            }
            return dto;
        }

        public UniversityNameCountryListDto GetNameAndCountryFromUniversities()
        {
            UniversityNameCountryListDto dto = new();
            try
            {
                dto.Universities = _universityRepository.GetAllUniversitiesFromDB().Select(x => new UniversityNameCountryDto()
                {
                    Name = x.Name,
                    Country = x.Country,
                }).ToList();
            }
            catch (Exception ex)
            {
                dto.HasErrors = true;
                dto.Error = UniversityEnumError.UnexpectedError;
                dto.ErrorMsg = $"Unexpected Error: {ex.Message}";
            }
            return dto;
        }

        public UniversityNameWebListListDto GetNameAndWebListFromUniversities(string name)
        {
            UniversityNameWebListListDto dto = new();
            if (!UniversityModelValidator.IsValidStringForSearch(name))
            {
                dto.HasErrors = true;
                dto.Error = UniversityEnumError.InvalidStringParameter;
                dto.ErrorMsg = $"The pattern provided is not valid to perform a search";
            }
            else
            {
                try
                {
                    UniversityListModel universityListModel = new();
                    universityListModel.universities = _universityRepository.GetAllUniversitiesFromDB()
                        .Select(x => new UniversityModel()
                        {
                            Name = x.Name,
                            WebPages = x.UniversityWebPage.Select(y => y.WebPage).ToList(),
                        }).ToList();
                    List<UniversityModel> matchingUniversities = universityListModel.GetUniversitiesWithNameContaining(name);
                    dto.Universities = matchingUniversities.Select(x => new UniversityNameWebListDto()
                    {
                        Name = x.Name,
                        Webs = x.WebPages,
                    }).ToList();
                }
                catch (Exception ex)
                {
                    dto.HasErrors = true;
                    dto.Error = UniversityEnumError.UnexpectedError;
                    dto.ErrorMsg = $"Unexpected Error: {ex.Message}";
                }
            }
            return dto;
        }









    }
}
