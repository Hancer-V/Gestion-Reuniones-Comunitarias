using System;

using Gestion_Reuniones.Domain.Core;

namespace Gestion_Reuniones.Domain.Entities
{
    public class Residente : BaseEntity
    {
        public string NombreCompleto { get; set; } = string.Empty;
        public string DocumentoIdentidad { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string UnidadVivienda { get; set; } = string.Empty; // Ej: "Apto 3B" o "Casa 12"
        public bool Activo { get; set; } = true;

        // Navegación
        public ICollection<Asistencia> Asistencias { get; set; } = new List<Asistencia>();
        public ICollection<Acuerdo> AcuerdosResponsable { get; set; } = new List<Acuerdo>();
    }
}