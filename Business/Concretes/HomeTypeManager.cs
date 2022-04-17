using BuildingSiteManagementWebApp.Business.Abstracts;
using BuildingSiteManagementWebApp.Data.Entities;
using BuildingSiteManagementWebApp.Data.Repository.Abstracts;
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
            _repository.Commit();
            await Task.CompletedTask;
        }

        public async Task ChangeNameAsync(int id, string newName)
        {
            _repository.Update(new HomeType { Id = id, Name = newName });
            _repository.Commit();
            await Task.CompletedTask;
        }

        public async Task ChangeNameAsync(string currentName, string newName)
        {
            var currentType = _repository.Get(n => n.Name == currentName);
            var newType = new HomeType { Id = currentType.Id, Name = newName };
            _repository.Update(newType);
            _repository.Commit();
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            _repository.Delete(t => t.Id == id);
            _repository.Commit();
            await Task.CompletedTask;

        }

        public async Task DeleteAsync(string name)
        {
            _repository.Delete(t => t.Name == name);
            _repository.Commit();
            await Task.CompletedTask;
        }

        public async Task<List<string>> GetAllNames()
        {
            return _repository.GetAll(null).Select(t => t.Name).ToList();
        }

        public async Task<string> GetNameAsync(int id)
        {
            return _repository.Get(t => t.Id == id).Name;
        }
    }
}
