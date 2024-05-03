using AutoMapper;
using WebApi.Domain.UserAggregate.Entities;
using WebApi.Shared.DTOs;

namespace WebApi.Server;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<Country, CountryDto>();
        CreateMap<Province, ProvinceDto>();
    }
}