using System.Runtime.Serialization;
using System.Security.Permissions;

namespace bootcamp_store_backend.Domain.Services
{
    [Serializable]
    internal class InvalidImageException : Exception
    {
        public InvalidImageException() { }

        public InvalidImageException(string? message) : base(message) { }

        public InvalidImageException(string? message, Exception? innerException) : base(message, innerException) { }

        public InvalidImageException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
