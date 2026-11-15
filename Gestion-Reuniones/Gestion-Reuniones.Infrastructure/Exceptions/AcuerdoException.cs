using System;

namespace Gestion_Reuniones.Infrastructure.Exceptions
{
    public class AcuerdoException : Exception
    {
        public AcuerdoException(string message) : base(message) { }
    }
}