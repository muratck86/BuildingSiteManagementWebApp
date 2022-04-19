using BuildingSiteManagementWebApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingSiteManagementWebApp.Business.Abstracts
{
    public interface IResidenceManager
    {
        Task AddResidenceAsync(Residence residence);
        Task<List<Residence>> GetAllResidencesAsync();
        Task<Residence> GetResidenceByIdAsync(int id);
        Task UpdateResidenceAsync(Residence residence);
        Task DeleteResidenceAsync(int id);
    }
}
