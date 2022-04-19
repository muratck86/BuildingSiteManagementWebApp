using BuildingSiteManagementWebApp.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingSiteManagementWebApp.Business.Abstracts
{
    public interface IInvoiceManager<T> where T : BaseInvoice
    {
        Task AddAsync(T invoice);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T invoice);
        Task DeleteAsync(int id);
    }
}
