using System;
using Gestion_Reuniones.Domain.Entities;
using Gestion_Reuniones.Infrastructure.Context;
using Gestion_Reuniones.Infrastructure.Core;
using Gestion_Reuniones.Infrastructure.Exceptions;
using Gestion_Reuniones.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Reuniones.Infrastructure.Repositories
{
    public class AsistenciaRepository : BaseRepository<Asistencia>, IAsistenciaRepository
    {
        public AsistenciaRepository(GestionReunionesContext context) : base(context) { }

        public override async Task AddAsync(Asistencia entity)
        {
            var yaRegistrada = await _dbSet.AnyAsync(a =>
                !a.Eliminado && a.ReunionId == entity.ReunionId && a.ResidenteId == entity.ResidenteId);

            if (yaRegistrada)
                throw new AsistenciaException("La asistencia de este residente ya fue registrada para esta reunión.");

            await base.AddAsync(entity);
        }

        public async Task<IEnumerable<Asistencia>> GetByReunionIdAsync(int reunionId) =>
            await _dbSet.Where(a => !a.Eliminado && a.ReunionId == reunionId).ToListAsync();
    }
}