using System.Runtime.Serialization;

namespace DevJoy
{
    [Serializable]
    internal class ValueNotFoundException : Exception
    {
        public ValueNotFoundException()
        {
        }

        public ValueNotFoundException(string? message) : base(message)
        {
        }

        public ValueNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}