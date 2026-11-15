using System;

namespace Gestion_Reuniones.Domain.Core
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime? FechaModificacion { get; set; }
        public bool Eliminado { get; set; } = false;
    }
}
