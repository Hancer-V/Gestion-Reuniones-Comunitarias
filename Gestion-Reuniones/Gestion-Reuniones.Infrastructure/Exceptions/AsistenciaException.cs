using System;

namespace Gestion_Reuniones.Infrastructure.Exceptions
{
    public class AsistenciaException : Exception
    {
        public AsistenciaException(string message) : base(message) { }
    }
}