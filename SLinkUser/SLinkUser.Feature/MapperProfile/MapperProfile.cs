using AutoMapper;
using SLinkUser.Domain.Entity;
using SLinkUser.Feature.Contracts;

namespace SLinkUser.Feature.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateUserRequest, User>().ForPath(dest => dest.Address!.Latitud, opt => opt.MapFrom(org => org.Address!.Geo!.Latitud)).
                                                 ForPath(dest => dest.Address!.Longitude, opt => opt.MapFrom(org => org.Address!.Geo!.Longitude)).
                                                 ForAllMembers(opts =>
                                                 {
                                                     opts.AllowNull();
                                                     opts.Condition((src, dest, srcMember) => srcMember != null);
                                                 });
        }
    }
}
