using System;
using Gestion_Reuniones.Domain.Entities;
using Gestion_Reuniones.Domain.Repository;

namespace Gestion_Reuniones.Infrastructure.Interfaces
{
    public interface IAcuerdoRepository : IBaseRepository<Acuerdo>
    {
        Task<IEnumerable<Acuerdo>> GetByReunionIdAsync(int reunionId);
        Task<IEnumerable<Acuerdo>> GetPendientesAsync();
    }
}