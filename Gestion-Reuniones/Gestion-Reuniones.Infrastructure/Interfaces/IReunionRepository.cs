using System;
using Gestion_Reuniones.Domain.Entities;
using Gestion_Reuniones.Domain.Repository;

namespace Gestion_Reuniones.Infrastructure.Interfaces
{
    public interface IReunionRepository : IBaseRepository<Reunion>
    {
        Task<IEnumerable<Reunion>> GetByEstadoAsync(string estado);
    }
}