using System.Runtime.Serialization;

namespace bootcamp_store_backend.Domain.Persistence
{
    [Serializable]
    internal class ForeingKeyException : Exception
    {
        public ForeingKeyException() { }

        public ForeingKeyException(string? message) : base(message) { }

        public ForeingKeyException(string? message, Exception? innerException) : base(message, innerException) { }

        public ForeingKeyException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}
