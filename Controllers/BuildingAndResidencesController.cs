using AutoMapper;
using BuildingSiteManagementWebApp.Business.Abstracts;
using BuildingSiteManagementWebApp.Data.Entities;
using BuildingSiteManagementWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingSiteManagementWebApp.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BuildingAndResidencesController : Controller
    {
        private readonly IBuildingManager _buildingManager;
        private readonly IResidenceManager _residenceManager;
        private readonly IHomeTypeManager _homeTypeManager;
        private readonly IMapper _mapper;

        public BuildingAndResidencesController(IServiceProvider serviceProvider)
        {
            _buildingManager = serviceProvider.GetRequiredService<IBuildingManager>();
            _residenceManager = serviceProvider.GetRequiredService<IResidenceManager>();
            _homeTypeManager = serviceProvider.GetRequiredService<IHomeTypeManager>();

            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public BuildingModelPackage BuildingModel { get; set; }
        public class BuildingModelPackage
        {
            public BuildingInputModel InputModel { get; set; }
            public List<BuildingViewModel> ViewModels { get; set; }
        }

        public ResidenceModelPackage ResidenceModel { get; set; }

        public class ResidenceModelPackage
        {
            public ResidenceInputModel InputModel { get; set; }
            public List<ResidenceViewModel> ViewModels { get; set; }
        }

        public async Task<IActionResult> Index()
        {
            var buildings = await _buildingManager.GetAllAsync();
            var viewModels = _mapper.Map<List<BuildingViewModel>>(buildings);
            BuildingModel = new BuildingModelPackage { ViewModels = viewModels };
            return View(BuildingModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddBuilding(BuildingInputModel buildingModel)
        {

            if (ModelState.IsValid)
            {
                var buildings = _mapper.Map<Building>(buildingModel);
                await _buildingManager.AddAsync(buildings);
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBuilding(int buildingId)
        {
            ViewBag.buildingId = buildingId;
            var building = await _buildingManager.GetByIdAsync(buildingId);
            if (building == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<BuildingInputModel>(building);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBuilding(BuildingInputModel model, int buildingId)
        {
            var building = await _buildingManager.GetByIdAsync(buildingId);
            if (building == null)
                return NotFound();
            if(ModelState.IsValid)
            {
                building.Name = model.Name;
                building.Basements = model.Basements;
                building.NumberOfFloors = model.NumberOfFloors;
                building.HasRoof = model.HasRoof;
                await _buildingManager.UpdateAsync(building);
                return RedirectToAction("Index");
            }
            return View("Index");

        }

        public async Task<IActionResult> DeleteBuilding(int buildingId)
        {
            await _buildingManager.DeleteAsync(buildingId);
            if (ModelState.IsValid)
                return RedirectToAction("Index");
            return View("NotFound");
        }

        [HttpGet]
        public async Task<IActionResult> Residences(int buildingId)
        {
            var building = await _buildingManager.GetByIdAsync(buildingId);
            ViewBag.building = building;
            ViewBag.homeTypes = await _homeTypeManager.GetAllAsync();
            var residences = await _residenceManager.GetAllByBuildingIdAsync(buildingId);
            var residenceModels = _mapper.Map<List<ResidenceViewModel>>(residences);
            ResidenceModel = new ResidenceModelPackage { ViewModels = residenceModels };
            return View(ResidenceModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddResidence(ResidenceInputModel model)
        {
            var residence = _mapper.Map<Residence>(model);
            residence.ResidenceType = new ResidenceType { HomeTypeId = model.ResidenceType };
            await _residenceManager.AddAsync(residence);
            return RedirectToAction("Residences", new {buildingId = model.BuildingId });
        }
        [HttpGet]
        public async Task<IActionResult> ResidenceDetails(int residenceId)
        {
            var residence = await _residenceManager.GetByIdAsync(residenceId);
            var residenceModel = _mapper.Map<ResidenceViewModel>(residence);
            return View(residenceModel);
        }
        public async Task<IActionResult> DeleteResidence(int residenceId)
        {
            var buildingId = _residenceManager.GetByIdAsync(residenceId).Result.BuildingId;
            await _residenceManager.DeleteAsync(residenceId);
            if (ModelState.IsValid)
                return RedirectToAction("Residences", new { buildingId = buildingId });
            return View("NotFound");
        }

        public async Task<IActionResult> UpdateResidence(int residenceId)
        {
            ViewBag.residenceId = residenceId;
            ViewBag.homeTypes = await _homeTypeManager.GetAllAsync();
            var residence = await _residenceManager.GetByIdAsync(residenceId);
            if (residence == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<ResidenceInputModel>(residence);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateResidence(ResidenceInputModel model, int residenceId)
        {
            var residence = await _residenceManager.GetByIdAsync(residenceId);
            if (residence == null)
                return NotFound();
            if (ModelState.IsValid)
            {
                residence.Floor = model.Floor;
                residence.DoorNo = model.DoorNo;
                residence.ResidenceType = new ResidenceType { HomeTypeId = model.ResidenceType };
                await _residenceManager.UpdateAsync(residence);
                return RedirectToAction("Residences", new { buildingId = residence.BuildingId });
            }
            return View("Index");

        }
    }
}
