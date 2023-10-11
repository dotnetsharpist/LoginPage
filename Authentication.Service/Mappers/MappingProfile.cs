using Authentication.Domain.Entities.User;
using Authentication.Service.DTOs.Users;
using AutoMapper;

namespace Authentication.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserCreateDto, User>();
    }
}