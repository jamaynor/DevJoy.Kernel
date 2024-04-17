

namespace DevJoy.Events
{
    public interface IAuditable
    {
        /// <summary>
        /// An identifier of the individual that initiated the event, or created the entity.
        /// </summary>
        string CreatedBy { get;  }

        /// <summary>
        /// The date and time the event occurred.
        /// </summary>
        DateTimeOffset CreatedAt { get;  }
    }
}
