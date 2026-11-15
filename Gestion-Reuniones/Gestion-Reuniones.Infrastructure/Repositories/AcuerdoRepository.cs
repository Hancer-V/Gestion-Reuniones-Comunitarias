using System;
using Gestion_Reuniones.Domain.Entities;
using Gestion_Reuniones.Infrastructure.Context;
using Gestion_Reuniones.Infrastructure.Core;
using Gestion_Reuniones.Infrastructure.Exceptions;
using Gestion_Reuniones.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Reuniones.Infrastructure.Repositories
{
    public class AcuerdoRepository : BaseRepository<Acuerdo>, IAcuerdoRepository
    {
        public AcuerdoRepository(GestionReunionesContext context) : base(context) { }

        public override async Task AddAsync(Acuerdo entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Titulo))
                throw new AcuerdoException("El título del acuerdo es obligatorio.");

            var existeReunion = await _context.Reuniones.AnyAsync(r => r.Id == entity.ReunionId && !r.Eliminado);
            if (!existeReunion)
                throw new AcuerdoException($"La reunión con Id {entity.ReunionId} no existe.");

            await base.AddAsync(entity);
        }

        public async Task<IEnumerable<Acuerdo>> GetByReunionIdAsync(int reunionId) =>
            await _dbSet.Where(a => !a.Eliminado && a.ReunionId == reunionId).ToListAsync();

        public async Task<IEnumerable<Acuerdo>> GetPendientesAsync() =>
            await _dbSet.Where(a => !a.Eliminado && a.EstadoSeguimiento != "Cumplido").ToListAsync();
    }
}