using BuildingSiteManagementWebApp.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingSiteManagementWebApp.Business.Abstracts
{
    public interface IHomeTypeManager : IManager<HomeType>
    {
        Task AddAsync(string name);
        Task DeleteAsync(string name);
        Task ChangeNameAsync(int id, string newName);
        Task ChangeNameAsync(string currentName, string newName);
        Task<string> GetNameAsync(int id);
        Task<List<string>> GetAllNames();
    }
}
