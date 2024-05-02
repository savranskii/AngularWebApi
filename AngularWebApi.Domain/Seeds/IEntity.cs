namespace AngularWebApi.Domain.Seeds;

public interface IEntity<T> where T : struct
{
}

public interface IEntity : IEntity<long>
{
    long Id { get; protected set; }
}
