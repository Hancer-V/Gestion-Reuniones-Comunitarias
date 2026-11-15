using System;

namespace Gestion_Reuniones.Infrastructure.Exceptions
{
    public class ReunionException : Exception
    {
        public ReunionException(string message) : base(message) { }
    }
}