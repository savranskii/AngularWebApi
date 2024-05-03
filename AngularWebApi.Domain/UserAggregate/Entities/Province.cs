using AngularWebApi.Domain.Seeds;

namespace AngularWebApi.Domain.UserAggregate.Entities;

public class Province : IEntity<long>
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public long CountryId { get; set; }
    public Country Country { get; set; } = null!;
}