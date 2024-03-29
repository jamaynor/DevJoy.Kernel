using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace DevJoy.Domain.Kernel;


/// <summary>
/// A domain object adhering to DDD principles. It has public property getters and
/// hidden (private, protected, internal) setters. It's state can only be modified by the 
/// AggregateRoot for which it is a property or field. Identity is a function of its ID 
/// rather than its attributes.
/// </summary>
public abstract class EntityBase<TId> : IEntity<TId>
{
    private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();


    /// <summary>An empty constructor is needed to support deserialization.</summary>
    protected EntityBase() { }


    /// <summary>The unique key that identifies an entity.</summary>
    public TId Id { get; protected set; } = default!;
    object IEntity.Id => Id!;


    /// <summary>A sequential id that is used to prevent concurrency issues.</summary>
    public int Version { get; protected set; }
    /// <summary>The universal DateTime at which this entity was last updated.</summary>
    public DateTimeOffset Lastupdated { get; protected set; }
    /// <summary>Convenience method that updated the entity version and the lastUpdated date.</summary>
    protected void IncrementVersionAndUpdatedAt()
    {
        this.Version++;
        this.Lastupdated = DateTimeOffset.UtcNow;
    }


    [NotMapped]
    public IEnumerable<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>Adds a domain event to the list.</summary>
    protected void RegisterDomainEvent(IDomainEvent domainEvent)
    {
        if (domainEvent == null) throw new ArgumentNullException(nameof(domainEvent));
        _domainEvents.Add(domainEvent);
    }

    /// <summary>Clears all domain events.</sumary>
    public void ClearDomainEvents() { _domainEvents.Clear(); }

    #region IEquatable<object>

    /// <summary>
    /// Compared the Ids of two <see cref="EntityBase{TId}"/>s to determine equality.
    /// </summary>
    public static bool operator ==(EntityBase<TId> obj1, EntityBase<TId> obj2)
    {
        if (Equals(obj1, null))
        {
            if (Equals(obj2, null))
            {
                return true;
            }
            return false;
        }
        return obj1.Equals(obj2);
    }

    /// <summary>
    /// Compared the Ids of two <see cref="EntityBase{TId}"/>s to determine equality.
    /// </summary>
    public static bool operator !=(EntityBase<TId> obj1, EntityBase<TId> obj2)
    {
        return !(obj1 == obj2);
    }

    /// <summary>
    /// Compared the Ids of two <see cref="EntityBase{TId}"/>s to determine equality.
    /// </summary>
    public override bool Equals(object? other)
    {
        if (other is null) return false;
        if (other.GetType().FullName != GetType().FullName) return false;

        var otherEntity = other as EntityBase<TId>;
        if (otherEntity is null) return false;

        return EqualityComparer<TId>.Default.Equals(Id, otherEntity.Id);
    }
    #endregion

    #region GetHashCode

    public override int GetHashCode()
    {
        if (hCode != 0) return hCode;
        hCode = 23;

        unchecked
        {
            foreach (PropertyInfo prop in GetType().GetProperties())
            {
                var h = GetPropertyHashCode(prop);
                hCode = hCode * h + h;
            }
        }
        return hCode;
    }
    private int hCode = 0;

    private int GetPropertyHashCode(PropertyInfo prop)
    {
        if (prop is null) return 31;
        if (prop.GetValue(this) is null) return 17;
        return prop.GetValue(this)!.GetHashCode();
    }
    #endregion
}
