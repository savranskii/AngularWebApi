using Microsoft.EntityFrameworkCore;
using WebApi.Domain.UserAggregate.Entities;
using WebApi.Domain.UserAggregate.Repositories;
using WebApi.Shared.Helpers;

namespace WebApi.Infrastructure.Repositories;

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