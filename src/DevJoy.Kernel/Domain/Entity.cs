
using System.Security.Cryptography;

namespace DevJoy.Domain
{
    /// <summary>
    /// The base class for an entity that provides the minimum properties needed.
    /// </summary>    
    public class Entity<TId> : IEntity<TId>
    {
        public TId Id { get; protected set; } = default!;

        public long Version { get; protected set; }

        public DateTimeOffset CreatedAt { get; protected set; } = DateTimeOffset.Now;

        public DateTimeOffset UpdatedAt { get; protected set; } = DateTimeOffset.Now;
    }

    /// <summary>
    /// The default base class for all entities that use a <see cref="Guid"/> as the identifier.
    /// </summary>
    public class Entity : Entity<Guid>{}
}
