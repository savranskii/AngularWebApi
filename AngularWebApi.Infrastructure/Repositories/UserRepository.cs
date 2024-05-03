using AngularWebApi.Application.Helpers;
using AngularWebApi.Domain.UserAggregate.Entities;
using AngularWebApi.Domain.UserAggregate.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AngularWebApi.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task<bool> IsUserExistAsync(string login)
    {
        return await context.Users.AnyAsync(u => u.Login == login);
    }

    public void RegisterUser(string login, string password, bool isAgreeToWorkForFood, int countryId, int provinceId)
    {
        var user = new User(login, isAgreeToWorkForFood, countryId, provinceId);
        user.UpdatePassword(PasswordHelper.SaltPassword(password, user.Salt));
        context.Users.Add(user);
    }
}