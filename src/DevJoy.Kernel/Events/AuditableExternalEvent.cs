namespace DevJoy.Events
{
    public record AuditableExternalEvent<TUserId> : IExternalEvent<TUserId>
    {
        public AuditableExternalEvent() { }
        public AuditableExternalEvent(TUserId createdBy, DateTimeOffset createdAt)
        {


            CreatedBy = createdBy;
            CreatedAt = createdAt;
        }

        public TUserId CreatedBy { get; init; } = default!;
        public DateTimeOffset CreatedAt { get; init; }
    }
}
