

namespace DevJoy.Domain
{
    /// <summary>
    /// The base class for an aggregate root that provides the basic properties
    /// of an entity, and implements the marker interface <see cref="IAggregateRoot"/>
    /// </summary>
    public class AggregateRoot<TId> : Entity<TId>, IAggregateRoot<TId> { }

    /// <summary>
    /// The default base class for all aggregate roots that use a <see cref="Guid"/> as the identifier.
    /// </summary>
    public class AggregateRoot : AggregateRoot<Guid> { }
}
