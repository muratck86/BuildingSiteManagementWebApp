using BuildingSiteManagementWebApp.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingSiteManagementWebApp.Business.Abstracts
{
    public interface IHomeTypeManager
    {
        Task AddAsync(string name);
        Task DeleteAsync(int id);
        Task DeleteAsync(string name);
        Task ChangeNameAsync(int id, string newName);
        Task ChangeNameAsync(string currentName, string newName);
        Task UpdateAsync(HomeType homeType);
        Task<string> GetNameAsync(int id);
        Task<List<string>> GetAllNames();
        Task<HomeType> GetAsync(int id);
    }
}
