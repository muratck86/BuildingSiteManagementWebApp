using BuildingSiteManagementWebApp.Business.Abstracts;
using BuildingSiteManagementWebApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingSiteManagementWebApp.Business.Concretes
{
    public class ResidenceManager : BaseManager<Residence>, IResidenceManager
    {
        public ResidenceManager(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public async Task<List<Residence>> GetAllByBuildingIdAsync(int id)
        {
            return await _repository.GetAll(x => x.BuildingId == id, r => r.User, r => r.Owner, r => r.ResidenceType).ToListAsync();
        }
        public async Task<List<Residence>> GetAllByOwnerIdAsync(string id)
        {
            return await _repository.GetAll(r => r.OwnerId == id, r => r.User, r => r.Building, r => r.ResidenceType).ToListAsync();
        }
    }
}
