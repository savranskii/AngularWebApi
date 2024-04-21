using AngularWebApi.Infrastructure.DTOs;
using AngularWebApi.Infrastructure.Models;

namespace AngularWebApi.Infrastructure.Interfaces;

public interface IRepository
{
    void RegisterUser(RegistrationRequest data);
    Task<List<Country>> GetCountriesAsync();
    Task<List<Province>> GetProvincesByCountryAsync(int countryId);
    Task SaveAsync();
}
