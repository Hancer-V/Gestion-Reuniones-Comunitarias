using System;

using Gestion_Reuniones.Domain.Core;

namespace Gestion_Reuniones.Domain.Entities
{
    public class Reunion : BaseEntity
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaHora { get; set; }
        public string Lugar { get; set; } = string.Empty;
        public string Estado { get; set; } = "Programada"; // Programada, Realizada, Cancelada

        // Navegación
        public ICollection<Asistencia> Asistencias { get; set; } = new List<Asistencia>();
        public ICollection<Acuerdo> Acuerdos { get; set; } = new List<Acuerdo>();
    }
}