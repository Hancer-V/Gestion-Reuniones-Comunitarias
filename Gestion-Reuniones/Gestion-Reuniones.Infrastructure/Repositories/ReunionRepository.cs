using System;
using Gestion_Reuniones.Domain.Entities;
using Gestion_Reuniones.Infrastructure.Context;
using Gestion_Reuniones.Infrastructure.Core;
using Gestion_Reuniones.Infrastructure.Exceptions;
using Gestion_Reuniones.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Reuniones.Infrastructure.Repositories
{
    public class ReunionRepository : BaseRepository<Reunion>, IReunionRepository
    {
        public ReunionRepository(GestionReunionesContext context) : base(context) { }

        public override async Task AddAsync(Reunion entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Titulo))
                throw new ReunionException("El título de la reunión es obligatorio.");

            await base.AddAsync(entity);
        }

        public async Task<IEnumerable<Reunion>> GetByEstadoAsync(string estado) =>
            await _dbSet.Where(r => !r.Eliminado && r.Estado == estado).ToListAsync();
    }
}
