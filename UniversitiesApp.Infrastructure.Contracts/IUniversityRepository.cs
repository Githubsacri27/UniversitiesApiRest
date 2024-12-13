using UniversitiesApp.Infrastructure.Contracts.Entities;

namespace UniversitiesApp.Infrastructure.Contracts
{
    public interface IUniversityRepository
    {
        public Task<int> UniversityMigrationFromAPI2DB();
        public List<University> GetAllUniversitiesFromDB();

    }
}
