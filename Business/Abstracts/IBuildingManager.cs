using BuildingSiteManagementWebApp.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingSiteManagementWebApp.Business.Abstracts
{
    public interface IBuildingManager
    {
        Task AddBuildingAsync(Building building);
        Task<List<Building>> GetAllBuildingsAsync();
        Task<Building> GetByIdAsync(int id);
        Task UpdateBuildingAsync(Building building);
        Task DeleteBuildingAsync(int id);
    }
}
