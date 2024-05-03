using WebApi.Domain.Seeds;

namespace WebApi.Domain.UserAggregate.Entities;

public class Country : IEntity<long>
{
    private Country()
    {
    }

    public Country(string name)
    {
        Name = name;
    }

    public Country(long id, string name)
    {
        Id = id;
        Name = name;
    }

    public string Name { get; private set; } = string.Empty;

    public ICollection<Province> Provinces { get; private set; } = [];
    public long Id { get; set; }
}