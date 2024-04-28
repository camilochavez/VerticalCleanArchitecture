using AutoMapper;
using SLinkUser.API.Features.Contract;
using SLinkUser.API.Features.CreateUser;
using SLinkUser.API.Features.UpdateUser;
using SLinkUser.Domain.DTO;
using SLinkUser.Domain.Entity;

namespace SLinkUser.API.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateUserCommand, UserDTO>();
            CreateMap<CompanyDTO, Company>();
            CreateMap<AddressDTO, Address>();
            CreateMap<UserDTO, User>().ForPath(dest => dest.Address, opt => opt.MapFrom(org => org.Address)).
                                                 ForPath(dest => dest.Address!.Latitud, opt => opt.MapFrom(org => org.Address!.Geo!.Latitud)).
                                                 ForPath(dest => dest.Address!.Longitude, opt => opt.MapFrom(org => org.Address!.Geo!.Longitude)).
                                                 ForPath(dest => dest.Company, opt => opt.MapFrom(org => org.Company)).
                                                 ForAllMembers(opts =>
                                                 {
                                                     opts.AllowNull();
                                                     opts.Condition((src, dest, srcMember) => srcMember != null);
                                                 });
            CreateMap<Company, CompanyDTO>();
            CreateMap<Address, AddressDTO>();
            CreateMap<User, UserDTO>().ForPath(dest => dest.Address, opt => opt.MapFrom(org => org.Address)).
                                                 ForPath(dest => dest.Address!.Geo!.Latitud, opt => opt.MapFrom(org => org.Address!.Latitud)).
                                                 ForPath(dest => dest.Address!.Geo!.Longitude, opt => opt.MapFrom(org => org.Address!.Longitude)).
                                                 ForPath(dest => dest.Company, opt => opt.MapFrom(org => org.Company)).
                                                 ForAllMembers(opts =>
                                                 {
                                                     opts.AllowNull();
                                                     opts.Condition((src, dest, srcMember) => srcMember != null);
                                                 });

            CreateMap<UpdateUserRequest, UpdateUserCommand>();
        }
    }
}
