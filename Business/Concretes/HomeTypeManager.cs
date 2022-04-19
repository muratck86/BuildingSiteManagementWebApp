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
    public class HomeTypeManager : IHomeTypeManager
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IRepository<HomeType> _repository;

        public HomeTypeManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _repository = _serviceProvider.GetRequiredService<IRepository<HomeType>>();
        }

        public async Task AddAsync(string name)
        {
            _repository.Create(new HomeType { Name = name });
            await _repository.CommitAsync();
        }

        public async Task ChangeNameAsync(int id, string newName)
        {
            var entity = await _repository.GetAsync(e => e.Id == id);
            entity.Name = newName;
            _repository.Update(entity);
            await _repository.CommitAsync();
        }

        public async Task ChangeNameAsync(string currentName, string newName)
        {
            var entity = await _repository.GetAsync(n => n.Name == currentName);
            entity.Name = newName;
            _repository.Update(entity);
            await _repository.CommitAsync();
        }
        public async Task UpdateAsync(HomeType homeType)
        {
            _repository.Update(homeType);
            await _repository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(t => t.Id == id);
            await _repository.CommitAsync();

        }

        public async Task DeleteAsync(string name)
        {
            await _repository.DeleteAsync(t => t.Name == name);
            await _repository.CommitAsync();
        }

        public async Task<List<string>> GetAllNames()
        {
            var result = await _repository.GetAll(null).Select(t => t.Name).ToListAsync();
            return result;
        }

        public async Task<string> GetNameAsync(int id)
        {
            var result = await _repository.GetAsync(t => t.Id == id);
            return result.Name;
        }

        public async Task<HomeType> GetAsync(int id)
        {
            var result = await _repository.GetAsync(t => t.Id == id);
            return result;
        }
    }
}
