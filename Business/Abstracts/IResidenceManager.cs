using BuildingSiteManagementWebApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingSiteManagementWebApp.Business.Abstracts
{
    public interface IResidenceManager
    {
        Task AddAsync(Residence residence);
        Task<List<Residence>> GetAllAsync();
        Task<List<Residence>> GetAllByBuildingIdAsync(int id);
        Task<List<Residence>> GetAllByOwnerIdAsync(string id);

        Task<Residence> GetByIdAsync(int id);
        Task UpdateAsync(Residence residence);
        Task DeleteAsync(int id);
    }

    public interface IMessageManager
    {
        Task SendMessageToAdmin(Message message);
        Task SendMessageFromAdmin(Message message);
        Task<List<Message>> GetAllAsync();
        Task<Message> GetById(int id);
        Task UpdateAsync(Message message);
        Task DeleteAsync(int id);
    }
}
