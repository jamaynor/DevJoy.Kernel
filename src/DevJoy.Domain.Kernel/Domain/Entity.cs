
namespace DevJoy.Domain
{
    public class Entity<TId> : IEntity<TId>
    {
        public TId Id { get; protected set; }

        public long Version { get; protected set; }

        public DateTimeOffset CreatedAt { get; protected set; }

        public DateTimeOffset UpdatedAt { get; protected set; }
    }
}
