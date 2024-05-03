using AngularWebApi.Domain.Seeds;

namespace AngularWebApi.Domain.UserAggregate.Entities;

public class User : IEntity<long>
{
    private User()
    {
    }

    public User(string login, bool isAgreeToWorkForFood, long countryId, long provinceId)
    {
        Login = login;
        IsAgreeToWorkForFood = isAgreeToWorkForFood;
        CountryId = countryId;
        ProvinceId = provinceId;
    }

    public string Login { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public bool IsAgreeToWorkForFood { get; private set; }
    public string Salt { get; private set; } = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public long CountryId { get; private set; }
    public Country Country { get; private set; } = null!;

    public long ProvinceId { get; private set; }
    public Province Province { get; private set; } = null!;
    public long Id { get; set; }

    public void UpdatePassword(string password)
    {
        Password = password;
    }
}