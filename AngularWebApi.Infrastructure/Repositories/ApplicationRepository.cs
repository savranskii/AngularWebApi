using AngularWebApi.Infrastructure.DTOs;
using AngularWebApi.Infrastructure.Interfaces;
using AngularWebApi.Infrastructure.Models;
using AngularWebApi.Infrastructure.Options;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text;

namespace AngularWebApi.Infrastructure.Repositories;

public class ApplicationRepository(ApplicationDbContext context, IOptions<ApplicationOptions> options) : IRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<bool> IsUserExistAsync(string login)
    {
        return await _context.Users.AnyAsync(u => u.Login == login);
    }

    public void RegisterUser(RegistrationRequest data)
    {
        _context.Users.Add(new User
        {
            Login = data.Login,
            Password = SaltPassword(data.Password, options.Value.Salt),
            IsAgreeToWorkForFood = data.IsAgreeToWorkForFood,
            CountryId = data.Country,
            ProvinceId = data.Province
        });
    }

    public async Task<List<Country>> GetCountriesAsync()
    {
        return await _context.Countries.ToListAsync();
    }

    public async Task<List<Province>> GetProvincesByCountryAsync(int countryId)
    {
        return await _context.Provinces.Where(p => p.CountryId == countryId).ToListAsync();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    private static string SaltPassword(string password, string salt)
    {
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password,
            Encoding.ASCII.GetBytes(salt),
            KeyDerivationPrf.HMACSHA256,
            100000,
            256 / 8));
    }
}