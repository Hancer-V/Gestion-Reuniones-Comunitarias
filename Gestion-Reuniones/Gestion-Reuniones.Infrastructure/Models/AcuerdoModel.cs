using System;
namespace Gestion_Reuniones.Infrastructure.Models
{
    public class AcuerdoModel
    {
        public int Id { get; set; }
        public int ReunionId { get; set; }
        public int? ResidenteResponsableId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaLimite { get; set; }
        public string EstadoSeguimiento { get; set; } = "Pendiente";
    }
}