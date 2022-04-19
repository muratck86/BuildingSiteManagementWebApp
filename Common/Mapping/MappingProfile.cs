using AutoMapper;
using BuildingSiteManagementWebApp.Business.Dtos;
using BuildingSiteManagementWebApp.Data.Entities;
using BuildingSiteManagementWebApp.Models;
using System.Linq;

namespace BuildingSiteManagementWebApp.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBuildingDto, Building>()
                .ForMember(d => d.Residences, opt => opt.Ignore());

            CreateMap<Building, BuildingViewModel>()
                .ForMember(d => d.NumberOfResidences, opt => opt.MapFrom(src => src.Residences.Count()));
        }
    }
}
