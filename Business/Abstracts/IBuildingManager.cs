using BuildingSiteManagementWebApp.Business.Dtos;
using BuildingSiteManagementWebApp.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingSiteManagementWebApp.Business.Abstracts
{
    public interface IBuildingManager
    {
        Task AddAsync(CreateBuildingDto building);
        Task<List<Building>> GetAllAsync();
        Task<Building> GetByIdAsync(int id);
        Task UpdateAsync(Building building);
        Task DeleteAsync(int id);
    }
}
