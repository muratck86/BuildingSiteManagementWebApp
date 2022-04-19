using BuildingSiteManagementWebApp.Business.Abstracts;
using BuildingSiteManagementWebApp.Data.Entities;
using BuildingSiteManagementWebApp.Data.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BuildingSiteManagementWebApp.Business.Concretes
{
    public class InvoiceManager<T> : IInvoiceManager<T> where T : BaseInvoice, new()
    {
        private readonly IRepository<T> _repository;
        public InvoiceManager(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<T>>();
        }
        public async Task AddAsync(T invoice)
        {
            _repository.Create(invoice);
            await _repository.CommitAsync();
        }

        public async Task<System.Collections.Generic.List<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _repository.GetAsync(e => e.Id == id);
            return result;
        }

        public async Task UpdateAsync(T invoice)
        {
            _repository.Update(invoice);
            await _repository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(e => e.Id == id);
            await _repository.CommitAsync();
        }
    }
}
