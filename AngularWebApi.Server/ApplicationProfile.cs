using AngularWebApi.Infrastructure.DTOs;
using AngularWebApi.Infrastructure.Models;
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