using AngularWebApi.ApplicationCore.Entities;
using AngularWebApi.ApplicationCore.Models.DTOs;

namespace AngularWebApi.ApplicationCore.Interfaces;

public interface IRepository
{
    Task<bool> IsUserExistAsync(string login);
    void RegisterUser(RegistrationRequest data);
    Task<List<Country>> GetCountriesAsync();
    Task<List<Province>> GetProvincesByCountryAsync(int countryId);
    Task SaveAsync();
}