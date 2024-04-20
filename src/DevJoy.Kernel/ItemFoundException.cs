using System.Runtime.Serialization;

namespace DevJoy
{
    [Serializable]
    public class ItemFoundException : ApplicationException
    {
        public ItemFoundException()
        {
        }

        public ItemFoundException(string? message) : base(message)
        {
        }

        public ItemFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ItemFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}