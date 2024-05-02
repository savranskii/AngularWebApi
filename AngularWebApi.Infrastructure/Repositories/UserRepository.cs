using AngularWebApi.Application.Helpers;
using Microsoft.EntityFrameworkCore;
using AngularWebApi.Domain.Seeds;
using AngularWebApi.Domain.UserAggregate.Entities;
using AngularWebApi.Domain.UserAggregate.Repositories;

namespace AngularWebApi.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public IUnitOfWork UnitOfWork => context;
    
    public async Task<bool> IsUserExistAsync(string login)
    {
        return await context.Users.AnyAsync(u => u.Login == login);
    }

    public void RegisterUser(string login, string password, bool isAgreeToWorkForFood, int countryId, int provinceId)
    {
        context.Users.Add(new User
        {
            Login = login,
            Password = PasswordHelper.SaltPassword(password, ""),
            IsAgreeToWorkForFood = isAgreeToWorkForFood,
            CountryId = countryId,
            ProvinceId = provinceId
        });
    }
}