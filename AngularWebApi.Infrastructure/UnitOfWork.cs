using AngularWebApi.Domain.Seeds;
using AngularWebApi.Domain.UserAggregate.Repositories;
using AngularWebApi.Infrastructure.Repositories;

namespace AngularWebApi.Infrastructure;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork, IAsyncDisposable
{
    private IUserRepository? _userRepository;
    private ICountryRepository? _countryRepository;
    private IProvinceRepository? _provinceRepository;
    
    public IUserRepository UserRepository => _userRepository ??= new UserRepository(context);
    public ICountryRepository CountryRepository => _countryRepository ??= new CountryRepository(context);
    public IProvinceRepository ProvinceRepository => _provinceRepository ??= new ProvinceRepository(context);
    
    public async Task SaveEntitiesAsync(CancellationToken ct = default)
    {
        await context.SaveChangesAsync(ct);
    }

    public void Dispose()
    {
        context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await context.DisposeAsync();
    }
}