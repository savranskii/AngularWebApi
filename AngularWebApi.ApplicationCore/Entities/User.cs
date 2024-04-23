namespace AngularWebApi.ApplicationCore.Entities;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool IsAgreeToWorkForFood { get; set; }

    public int CountryId { get; set; }
    public Country Country { get; set; } = null!;

    public int ProvinceId { get; set; }
    public Province Province { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}