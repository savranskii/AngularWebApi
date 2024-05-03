using AngularWebApi.Domain.Seeds;

namespace AngularWebApi.Domain.UserAggregate.Entities;

public class Province : IEntity<long>
{
    private Province()
    {
    }

    public Province(string name)
    {
        Name = name;
    }

    public Province(long id, string name)
    {
        Id = id;
        Name = name;
    }

    public Province(long id, long countryId, string name)
    {
        Id = id;
        Name = name;
        CountryId = countryId;
    }

    public string Name { get; private set; } = string.Empty;

    public long CountryId { get; private set; }
    public Country Country { get; private set; } = null!;
    public long Id { get; set; }
}