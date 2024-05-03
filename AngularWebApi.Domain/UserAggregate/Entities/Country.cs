using AngularWebApi.Domain.Seeds;

namespace AngularWebApi.Domain.UserAggregate.Entities;

public class Country : IEntity<long>
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Province> Provinces { get; set; } = [];
}