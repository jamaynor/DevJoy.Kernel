
namespace DevJoy.Domain
{
    public interface IEntity<TId>
    {
        TId Id { get; }

        long Version { get; }

        DateTimeOffset CreatedAt { get; }

        DateTimeOffset UpdatedAt { get; }
    }
}