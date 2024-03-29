namespace DevJoy.Domain.Kernel;

/// <summary>
/// A marker interface for Domain Events
/// </summary>
public interface IDomainEvent { }

/// <summary>Interface for events that can be tracked by who issued the event, and when the event occured.</summary>
public interface IAuditableDomainEvent : IDomainEvent
{
    string IssuedBy { get; }
    public DateTimeOffset OccuredAt { get; }
}

public abstract record AuditableEvent  : IAuditableDomainEvent
{
    public string IssuedBy { get; init; } = string.Empty;
    public DateTimeOffset OccuredAt { get; init; }
}
