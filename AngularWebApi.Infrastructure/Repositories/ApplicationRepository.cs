﻿using AngularWebApi.Infrastructure.DTOs;
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

    public void RegisterUser(RegistrationRequest data)
    {
        _context.Users.Add(new User
        {
            Login = data.Login,
            Password = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: data.Password,
                salt: Encoding.ASCII.GetBytes(options.Value.Salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8)),
            IsAgreeToWorkForFood = data.IsAgreeToWorkForFood,
            CountryId = data.Country,
            ProvinceId = data.Province,
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
}