using AngularWebApi.Application.DTOs;
using AngularWebApi.Domain.UserAggregate.Entities;
using AutoMapper;

namespace AngularWebApi.Server;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<Country, CountryDto>();
        CreateMap<Province, ProvinceDto>();
    }
}