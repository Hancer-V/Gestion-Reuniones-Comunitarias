using System;
namespace Gestion_Reuniones.Infrastructure.Models
{
    public class AsistenciaModel
    {
        public int Id { get; set; }
        public int ReunionId { get; set; }
        public int ResidenteId { get; set; }
        public bool Asistio { get; set; }
        public DateTime? HoraLlegada { get; set; }
        public string Observaciones { get; set; } = string.Empty;
    }
}