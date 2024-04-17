using System.Runtime.Serialization;

namespace DevJoy
{
    [Serializable]
    internal class ElementFoundException : ApplicationException
    {
        public ElementFoundException()
        {
        }

        public ElementFoundException(string? message) : base(message)
        {
        }

        public ElementFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ElementFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}