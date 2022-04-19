using AutoMapper;
using BuildingSiteManagementWebApp.Business.Abstracts;
using BuildingSiteManagementWebApp.Business.Dtos;
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
        private readonly IRepository<Building> _repository;
        private readonly IMapper _mapper;

        public BuildingManager(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<Building>>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public async Task AddAsync(CreateBuildingDto building)
        {
            var newBuilding = _mapper.Map<Building>(building);
            _repository.Create(newBuilding);
            await _repository.CommitAsync();
        }
        public async Task<List<Building>> GetAllAsync()
        {
            return await _repository.GetAll(null, r => r.Residences).ToListAsync();
        }
        public async Task<Building> GetByIdAsync(int id)
        {
            return await _repository.GetAsync(t => t.Id == id, x => x.Residences);
        }
        public async Task UpdateAsync(Building building)
        {
            _repository.Update(building);
            await _repository.CommitAsync();
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(t => t.Id == id);
            await _repository.CommitAsync();
        }
    }
}
