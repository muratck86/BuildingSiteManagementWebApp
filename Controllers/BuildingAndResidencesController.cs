using AutoMapper;
using BuildingSiteManagementWebApp.Business.Abstracts;
using BuildingSiteManagementWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingSiteManagementWebApp.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BuildingAndResidencesController : Controller
    {
        private readonly IBuildingManager _buildingManager;
        private readonly IResidenceManager _residentManager;
        private readonly IMapper _mapper;

        public BuildingAndResidencesController(IBuildingManager buildingManager, IResidenceManager residentManager, IMapper mapper)
        {
            _buildingManager = buildingManager;
            _residentManager = residentManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var buildings = await _buildingManager.GetAllAsync();
            var buildingModels = _mapper.Map<List<BuildingViewModel>>(buildings);
            return View(buildingModels);
        }
        public IActionResult Manage(int buildingId)
        {
            return View("Index");
        }
        public  IActionResult Delete(int buildingId)
        {

            return View("Index");
        }
    }
}
