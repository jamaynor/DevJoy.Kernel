namespace DevJoy.Domain.Kernel
{
    public interface IEntity<TId> : IEntity
    {
        new TId Id { get; }
    }

    public interface IEntity
    {
        IEnumerable<IDomainEvent> DomainEvents { get; }
        object Id { get; }
        int Version { get; }

        void ClearDomainEvents();
        bool Equals(object? other);
        int GetHashCode();
    }
}