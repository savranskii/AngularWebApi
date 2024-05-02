namespace AngularWebApi.Domain.Seeds;

public interface IUnitOfWork : IDisposable
{
    Task SaveEntitiesAsync(CancellationToken ct = default);
}