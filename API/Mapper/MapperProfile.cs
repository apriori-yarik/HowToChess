using AutoMapper;
using Business.Dtos.Role;
using Business.Dtos.User;
using DataAccess.Entities;

namespace API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserDtoWithId>().ReverseMap();
            CreateMap<User, UserDtoWithIdWithoutRole>().ReverseMap();
            CreateMap<Role, RoleDtoWithId>().ReverseMap();

        }
    }
}
