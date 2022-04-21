using BuildingSiteManagementWebApp.Business.Abstracts;
using BuildingSiteManagementWebApp.Data.Entities;
using System;

namespace BuildingSiteManagementWebApp.Business.Concretes
{

    public class BuildingManager : BaseManager<Building>, IBuildingManager
    {
        public BuildingManager(IServiceProvider serviceProvider) : base(serviceProvider) { }

    }
}
