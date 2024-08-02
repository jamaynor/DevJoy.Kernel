namespace DevJoy.Events
{
    public record AuditableDomainEvent : IAuditable, IDomainEvent
    {
        public AuditableDomainEvent() { }
        public AuditableDomainEvent(string createdBy, DateTimeOffset createdAt)
        {
            if (string.IsNullOrEmpty(createdBy))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(createdBy));
            }

            CreatedBy = createdBy;
            CreatedAt = createdAt;
        }

        public string CreatedBy { get; init; } = string.Empty;
        public DateTimeOffset CreatedAt { get; init; }
    }
}