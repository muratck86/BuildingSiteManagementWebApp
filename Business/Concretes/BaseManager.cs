using AutoMapper;
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
    public class BaseManager<T> : IManager<T> where T : BaseEntity, new()
    {
        internal readonly IRepository<T> _repository;
        public BaseManager(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<T>>();
        }
        public async Task AddAsync(T entity)
        {
            _repository.Create(entity);
            await _repository.CommitAsync();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _repository.GetAll(null).ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetAsync(t => t.Id == id);
        }
        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _repository.CommitAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _repository.Delete(entity);
            await _repository.CommitAsync();
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(t => t.Id == id);
            await _repository.CommitAsync();
        }
    }
}
