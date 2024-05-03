using AngularWebApi.Domain.Seeds;

namespace AngularWebApi.Domain.UserAggregate.Entities;

public class Province : IEntity<long>
{
    public long Id { get; set; }
    public string Name { get; private set; } = string.Empty;

    public long CountryId { get; private set; }
    public Country Country { get; private set; } = null!;
    
    private Province()
    {
    }

    public Province(string name) => Name = name;

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
}