using AutoMapper;
using BuildingSiteManagementWebApp.Data.Entities;
using BuildingSiteManagementWebApp.Models;
using System.Linq;

namespace BuildingSiteManagementWebApp.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Building and residences
            CreateMap<Building, BuildingViewModel>()
                .ForMember(d => d.NumberOfResidences, opt => opt.MapFrom(src => src.Residences.Count()));
            CreateMap<BuildingInputModel, Building>().ReverseMap();
            CreateMap<Residence, ResidenceViewModel>().ReverseMap();
            CreateMap<ResidenceInputModel, Residence>().ReverseMap();

            CreateMap<AppUser, BuildingSiteManagementWebApp.Areas.Identity.Pages.Account.Manage.IndexModel.InputModel>().ReverseMap();
        }
    }
}
