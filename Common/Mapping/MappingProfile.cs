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
            CreateMap<Residence, ResidenceViewModel>().ForMember(dest => dest.ResidenceType, opt =>
            {
                opt.PreCondition(src => src.ResidenceType != null);
                opt.MapFrom(src => src.ResidenceType.HomeType);
            });
            CreateMap<HomeType, string>().ConvertUsing(ht => ht.Name);
            CreateMap<ResidenceType, string>().ConvertUsing(rt => rt.HomeType.Name);
            CreateMap<ResidenceType, int>().ConvertUsing(rt => rt.HomeType.Id);

            CreateMap<ResidenceInputModel, Residence>().ForMember(dest => dest.ResidenceType, opt => opt.Ignore());
            CreateMap<Residence, ResidenceInputModel>().ForMember(dest => dest.ResidenceType, opt =>
            {
                opt.PreCondition(src => src.ResidenceType != null);
                opt.MapFrom(src => src.ResidenceType.HomeTypeId);
            });
            CreateMap<string, HomeType>().ConstructUsing(ht => new HomeType { Name = ht} );
            CreateMap<int, ResidenceType>().ConstructUsing(r => new ResidenceType { HomeTypeId = r });


            CreateMap<AppUser, BuildingSiteManagementWebApp.Areas.Identity.Pages.Account.Manage.IndexModel.InputModel>().ReverseMap();
        }
    }
}
