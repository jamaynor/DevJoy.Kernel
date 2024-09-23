namespace DevJoy.Events
{
    public record AuditableDomainEvent<TUserId> : IDomainEvent<TUserId>
    {
        public AuditableDomainEvent() { }
        public AuditableDomainEvent(TUserId createdBy, DateTimeOffset createdAt)
        {
            if (EqualityComparer<TUserId>.Default.Equals(createdBy, default))
            {
                throw new ArgumentException("CreatedBy cannot be default", nameof(createdBy));
            }

            if (createdAt == DateTimeOffset.MaxValue
             || createdAt == DateTimeOffset.MinValue)
            {
                throw new ArgumentException("CreatedAt cannot be default", nameof(createdAt));
            }

            CreatedBy = createdBy;
            CreatedAt = createdAt;
        }

        public TUserId CreatedBy { get; init; } = default!;
        public DateTimeOffset CreatedAt { get; init; }
    }
}