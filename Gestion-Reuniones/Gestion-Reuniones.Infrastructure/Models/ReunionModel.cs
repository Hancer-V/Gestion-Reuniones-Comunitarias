using System;
namespace Gestion_Reuniones.Infrastructure.Models
{
    public class ReunionModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaHora { get; set; }
        public string Lugar { get; set; } = string.Empty;
        public string Estado { get; set; } = "Programada";
    }
}