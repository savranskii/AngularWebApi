using AngularWebApi.Domain.Seeds;

namespace AngularWebApi.Domain.UserAggregate.Repositories;

public interface IUserRepository
{
    IUnitOfWork UnitOfWork { get; }
    Task<bool> IsUserExistAsync(string login);
    void RegisterUser(string login, string password, bool isAgreeToWorkForFood, int countryId, int provinceId);
}