using BuildingSiteManagementWebApp.Business.Abstracts;
using BuildingSiteManagementWebApp.Data.Entities;
using BuildingSiteManagementWebApp.Data.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingSiteManagementWebApp.Business.Concretes
{

    public class BuildingManager : IBuildingManager
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IRepository<Building> _repository;

        public BuildingManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _repository = _serviceProvider.GetRequiredService<IRepository<Building>>();
        }

        public async Task AddBuildingAsync(Building building)
        {
            _repository.Create(building);
            await _repository.CommitAsync();
        }
        public async Task<List<Building>> GetAllBuildingsAsync()
        {
            return await _repository.GetAll(null, r => r.Residences).ToListAsync();
        }
        public async Task<Building> GetByIdAsync(int id)
        {
            return await _repository.GetAsync(t => t.Id == id, x => x.Residences);
        }
        public async Task UpdateBuildingAsync(Building building)
        {
            _repository.Update(building);
            await _repository.CommitAsync();
        }
        public async Task DeleteBuildingAsync(int id)
        {
            await _repository.DeleteAsync(t => t.Id == id);
            await _repository.CommitAsync();
        }
    }
}
