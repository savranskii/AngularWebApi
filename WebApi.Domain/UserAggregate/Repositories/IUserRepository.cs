namespace WebApi.Domain.UserAggregate.Repositories;

public interface IUserRepository
{
    Task<bool> IsUserExistAsync(string login);
    void RegisterUser(string login, string password, bool isAgreeToWorkForFood, int countryId, int provinceId);
}