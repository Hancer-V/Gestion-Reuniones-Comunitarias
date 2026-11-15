using System;
using Gestion_Reuniones.Domain.Entities;
using Gestion_Reuniones.Domain.Repository;

namespace Gestion_Reuniones.Infrastructure.Interfaces
{
    public interface IAsistenciaRepository : IBaseRepository<Asistencia>
    {
        Task<IEnumerable<Asistencia>> GetByReunionIdAsync(int reunionId);
    }
}