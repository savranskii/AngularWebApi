using WebApi.Domain.Seeds;
using WebApi.Domain.UserAggregate.Repositories;
using WebApi.Infrastructure.Repositories;

namespace WebApi.Infrastructure;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork, IAsyncDisposable
{
    private ICountryRepository? _countryRepository;
    private IProvinceRepository? _provinceRepository;
    private IUserRepository? _userRepository;

    public async ValueTask DisposeAsync()
    {
        await context.DisposeAsync();
    }

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
}