using System;

namespace Domain.Exceptions
{
    public class ChatsDomainException : Exception
    {
        public ChatsDomainException()
        { }

        public ChatsDomainException(string mensaje) : base(mensaje)
        { }

        public ChatsDomainException(string mensaje,
            Exception innerException) : base(mensaje, innerException)
        { }

    }
}
