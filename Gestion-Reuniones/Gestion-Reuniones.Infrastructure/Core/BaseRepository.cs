using System;

using Gestion_Reuniones.Domain.Core;
using Gestion_Reuniones.Domain.Repository;
using Gestion_Reuniones.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Reuniones.Infrastructure.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly GestionReunionesContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(GestionReunionesContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync() =>
            await _dbSet.Where(x => !x.Eliminado).ToListAsync();

        public virtual async Task<T?> GetByIdAsync(int id) =>
            await _dbSet.FirstOrDefaultAsync(x => x.Id == id && !x.Eliminado);

        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            entity.FechaModificacion = DateTime.UtcNow;
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                entity.Eliminado = true;
                entity.FechaModificacion = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }
    }
}