using System;

using Gestion_Reuniones.Domain.Core;

namespace Gestion_Reuniones.Domain.Entities
{
    public class Asistencia : BaseEntity
    {
        public int ReunionId { get; set; }
        public int ResidenteId { get; set; }
        public bool Asistio { get; set; }
        public DateTime? HoraLlegada { get; set; }
        public string Observaciones { get; set; } = string.Empty;

        // Navegación
        public Reunion? Reunion { get; set; }
        public Residente? Residente { get; set; }
    }
}