using BuildingSiteManagementWebApp.Data.Entities;
using BuildingSiteManagementWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingSiteManagementWebApp.Business.Abstracts
{
    public interface IResidenceManager : IManager<Residence>
    {
        Task<List<Residence>> GetAllByBuildingIdAsync(int id);
        Task<List<Residence>> GetAllByOwnerIdAsync(string id);

    }
}
