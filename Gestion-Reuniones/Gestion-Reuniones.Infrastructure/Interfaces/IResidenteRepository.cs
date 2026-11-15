using System;
using Gestion_Reuniones.Domain.Entities;
using Gestion_Reuniones.Domain.Repository;

namespace Gestion_Reuniones.Infrastructure.Interfaces
{
    public interface IResidenteRepository : IBaseRepository<Residente>
    {
        Task<Residente?> GetByDocumentoAsync(string documento);
    }
}