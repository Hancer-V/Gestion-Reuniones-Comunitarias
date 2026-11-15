using System;

using Gestion_Reuniones.Domain.Core;

namespace Gestion_Reuniones.Domain.Entities
{
    public class Acuerdo : BaseEntity
    {
        public int ReunionId { get; set; }
        public int? ResidenteResponsableId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaLimite { get; set; }
        public string EstadoSeguimiento { get; set; } = "Pendiente"; // Pendiente, EnProgreso, Cumplido

        // Navegación
        public Reunion? Reunion { get; set; }
        public Residente? ResidenteResponsable { get; set; }
    }
}