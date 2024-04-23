using AngularWebApi.ApplicationCore.Entities;
using AngularWebApi.ApplicationCore.Models.DTOs;
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