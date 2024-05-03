using AngularWebApi.Domain.Seeds;

namespace AngularWebApi.Domain.UserAggregate.Entities;

public class Country : IEntity<long>
{
    public long Id { get; set; }
    public string Name { get; private set; } = string.Empty;

    public ICollection<Province> Provinces { get; private set; } = [];

    private Country()
    {
    }

    public Country(string name) => Name = name;

    public Country(long id, string name)
    {
        Id = id;
        Name = name;
    }
}