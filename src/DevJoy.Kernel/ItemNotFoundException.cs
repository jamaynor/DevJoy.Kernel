using System.Runtime.Serialization;

namespace DevJoy
{
    [Serializable]
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException()
        {
        }

        public ItemNotFoundException(string? message) : base(message)
        {
        }

        public ItemNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ItemNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}