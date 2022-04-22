using BuildingSiteManagementWebApp.Business.Abstracts;
using BuildingSiteManagementWebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingSiteManagementWebApp.Business.Concretes
{
    public class ResidentManager : IResidentManager
    {
        public Task AddAsync(Resident entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Resident entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Resident>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Resident> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Resident entity)
        {
            throw new NotImplementedException();
        }
    }
}
