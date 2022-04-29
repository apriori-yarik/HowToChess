using AutoMapper;
using Business.Dtos.Game;
using Business.Dtos.Position;
using Business.Dtos.Role;
using Business.Dtos.User;
using Business.Dtos.UserPosition;
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
            CreateMap<User, UserDtoWithIdWithCollections>().ReverseMap();

            CreateMap<Role, RoleDtoWithId>().ReverseMap();

            CreateMap<Position, PositionDto>().ReverseMap();
            CreateMap<Position, PositionDtoWithId>().ReverseMap();

            CreateMap<UserPosition, UserPositionPositionDto>().ReverseMap();
            CreateMap<UserPosition, UserPositionUserDto>().ReverseMap();
            CreateMap<UserPosition, UserPositionUserDto>().ReverseMap();

            CreateMap<Game, GameDto>().ReverseMap();
            CreateMap<Game, GameDtoWithId>().ReverseMap();
            CreateMap<Game, GameDtoWithIdWithNavigations>().ReverseMap();
        }
    }
}
