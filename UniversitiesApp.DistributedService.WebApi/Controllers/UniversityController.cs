using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversitiesApp.Library.Contracts;
using UniversitiesApp.Library.Contracts.DTOs;

namespace UniversitiesApp.DistributedService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {

        private readonly IUniversityService _universityService;

        public UniversityController(IUniversityService universityService)
        {
            _universityService = universityService;
        }

        /// <summary>
        /// OPERACIÓN SOBRE API
        /// Obtiene la lista de universidades disponibles.
        /// </summary>

        //[HttpGet("GetUniversities")]
        //public async Task<ActionResult<List<UniversityDto>>> GetUniversities()
        //{
        //    // Llama al servicio para obtener la lista de universidades
        //    var universities = await _universityService.GetUniversityAsync();
        //    if (universities == null || !universities.Any())
        //    {
        //        return NotFound("No universities found.");
        //    }
        //    // Devuelve la lista de universidades en formato JSON
        //    return Ok(universities);
        //}

        //[HttpGet("GetUniversitiesByName")]

        //public async Task<ActionResult<List<UniversityNamesDto>>> GetUniversitiesByName()
        //{
        //    var universitiesNames = await _universityService.GetUniversityByNamesAsync();
        //    if(universitiesNames == null || !universitiesNames.Any())
        //    {
        //        return BadRequest("No university names found");
        //    }
        //    return Ok(universitiesNames);
        //}

        [HttpGet("MigrateFromAPI2DB")]
        public async Task<ActionResult<UniversityMigrationDto>> MigrateFromAPI2DB()
        {
            UniversityMigrationDto response = await _universityService.ExecuteMigrationFromAPI2DB();
            if (response.HasErrors) return BadRequest(response.ErrorMsg);
            return Ok(response);
        }

        [HttpGet("GetNamesAndCountriesFromUniversities")]
        public ActionResult<UniversityNameCountryListDto> GetNamesAndCountriesFromUniversities()
        {
            UniversityNameCountryListDto response = _universityService.GetNameAndCountryFromUniversities();
            if (response.HasErrors) return BadRequest(response.ErrorMsg);
            return Ok(response);
        }

        [HttpGet("GetNamesAndWebListFromUniversities")]
        public ActionResult<UniversityNameWebListListDto> GetNamesAndWebListFromUniversities([FromQuery] string pattern)
        {
            UniversityNameWebListListDto response = _universityService.GetNameAndWebListFromUniversities(pattern);
            if (response.HasErrors) return BadRequest(response.ErrorMsg);
            return Ok(response);
        }






    }
}
