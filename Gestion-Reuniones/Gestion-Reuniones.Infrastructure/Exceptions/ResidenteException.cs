using System;

namespace Gestion_Reuniones.Infrastructure.Exceptions
{
    public class ResidenteException : Exception
    {
        public ResidenteException(string message) : base(message) { }
    }
}
