using AutoMapper;
using Bioscope.App.Dtos;
using Bioscope.Data.Entities;

namespace Bioscope.App.Helpers
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
      CreateMap<Role, RoleDto>();
      CreateMap<RoleDto, Role>();

      CreateMap<User, SignupDto>();
      CreateMap<SignupDto, User>();

      CreateMap<User, AuthDto>();

      CreateMap<User, AuthDto>()
        .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId));
      CreateMap<AuthDto, User>();

      CreateMap<Feature, FeatureDto>();
      CreateMap<FeatureDto, Feature>();

      CreateMap<Menu, MenuDto>()
        .ForMember(dest => dest.FeatureId, opt => opt.MapFrom(src => src.FeatureId));
      CreateMap<MenuDto, Menu>();

      CreateMap<Subscription, SubscriptionDto>();
      CreateMap<SubscriptionDto, Subscription>();

      CreateMap<City, CityDto>();
      CreateMap<CityDto, City>();

      CreateMap<RoleFeature, RoleFeatureDto>();
      CreateMap<RoleFeatureDto, RoleFeature>();
    }
  }
}