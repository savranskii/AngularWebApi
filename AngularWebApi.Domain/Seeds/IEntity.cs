namespace AngularWebApi.Domain.Seeds;

public interface IEntity<T> where T : struct
{
    T Id { get; protected set; }
}