using System;
namespace Gestion_Reuniones.Infrastructure.Models
{
    public class ResidenteModel
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string DocumentoIdentidad { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string UnidadVivienda { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
    }
}