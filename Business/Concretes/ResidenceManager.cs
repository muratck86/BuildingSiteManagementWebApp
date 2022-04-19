using BuildingSiteManagementWebApp.Business.Abstracts;
using BuildingSiteManagementWebApp.Data.Entities;
using BuildingSiteManagementWebApp.Data.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingSiteManagementWebApp.Business.Concretes
{
    public class ResidenceManager : IResidenceManager
    {
        private readonly IRepository<Residence> _repository;

        public ResidenceManager(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<Residence>>();
        }

        public async Task AddAsync(Residence residence)
        {
            _repository.Create(residence);
            await _repository.CommitAsync();
        }
        public async Task<List<Residence>> GetAllAsync()
        {
            return await _repository.GetAll(null, r => r.User, r => r.Owner, r => r.Building, r => r.ResidenceType).ToListAsync();
        }
        public async Task<List<Residence>> GetAllByBuildingIdAsync(int id)
        {
            return await _repository.GetAll(x => x.BuildingId == id, r => r.User, r => r.Owner, r => r.ResidenceType).ToListAsync();
        }
        public async Task<List<Residence>> GetAllByOwnerIdAsync(string id)
        {
            return await _repository.GetAll(r => r.OwnerId == id, r => r.User, r => r.Building, r => r.ResidenceType).ToListAsync();
        }
        public async Task<Residence> GetByIdAsync(int id)
        {
            var result = await _repository.GetAsync(x => x.Id == id, r => r.User, r => r.Owner, r => r.Building, r => r.ResidenceType);
            return result;
        }
        public async Task UpdateAsync(Residence residence)
        {
            _repository.Update(residence);
            await _repository.CommitAsync();
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(x => x.Id == id);
            await _repository.CommitAsync();
        }
    }
}
