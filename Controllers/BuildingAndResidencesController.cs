using AutoMapper;
using BuildingSiteManagementWebApp.Business.Abstracts;
using BuildingSiteManagementWebApp.Common.Constants;
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
        private readonly IMapper _mapper;

        public BuildingAndResidencesController(IServiceProvider serviceProvider)
        {
            _buildingManager = serviceProvider.GetRequiredService<IBuildingManager>();
            _residenceManager = serviceProvider.GetRequiredService<IResidenceManager>();
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
        public async Task<IActionResult> Add(BuildingInputModel buildingModel)
        {
            var buildings = _mapper.Map<Building>(buildingModel);
            await _buildingManager.AddAsync(buildings);
            if (ModelState.IsValid)
                return RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int buildingId)
        {
            ViewBag.buildingId = buildingId;
            var building = await _buildingManager.GetByIdAsync(buildingId);
            if (building == null)
            {
                ViewBag.ErrorMessage = buildingId + " " + TextsLang.BuildingNotFound;
                return View("Not Found");
            }
            var model = _mapper.Map<BuildingInputModel>(building);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BuildingInputModel model, int buildingId)
        {
            var building = await _buildingManager.GetByIdAsync(buildingId);
            if (building == null)
                return View();
            building.Name = model.Name;
            building.Basements = model.Basements;
            building.NumberOfFloors = model.NumberOfFloors;
            building.HasRoof = model.HasRoof;
            await _buildingManager.UpdateAsync(building);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int buildingId)
        {
            await _buildingManager.DeleteAsync(buildingId);
            if (ModelState.IsValid)
                return RedirectToAction("Index");
            return View("NotFound");
        }

        [HttpGet]
        public async Task<IActionResult> Manage(int buildingId)
        {
            var building = await _buildingManager.GetByIdAsync(buildingId);
            ViewBag.BuildingName = building.Name;
            ViewBag.buildingId = buildingId;
            var residences = await _residenceManager.GetAllByBuildingIdAsync(buildingId);
            var residenceModels = _mapper.Map<List<ResidenceViewModel>>(residences);
            ResidenceModel = new ResidenceModelPackage { ViewModels = residenceModels };
            return View(ResidenceModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddResidence(ResidenceInputModel model)
        {
            var residence = _mapper.Map<Residence>(model);
            await _residenceManager.AddAsync(residence);
            return RedirectToAction("Manage", new {buildingId = model.BuildingId });
        }
        [HttpGet]
        public async Task<IActionResult> ResidenceDetails(int residenceId)
        {
            var residence = await _residenceManager.GetByIdAsync(residenceId);
            var residenceModel = _mapper.Map<ResidenceViewModel>(residence);
            return View(residenceModel);
        }
    }
}
