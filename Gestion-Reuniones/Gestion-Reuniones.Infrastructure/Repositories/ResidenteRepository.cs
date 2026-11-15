using System;
using Gestion_Reuniones.Domain.Entities;
using Gestion_Reuniones.Infrastructure.Context;
using Gestion_Reuniones.Infrastructure.Core;
using Gestion_Reuniones.Infrastructure.Exceptions;
using Gestion_Reuniones.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Reuniones.Infrastructure.Repositories
{
    public class ResidenteRepository : BaseRepository<Residente>, IResidenteRepository
    {
        public ResidenteRepository(GestionReunionesContext context) : base(context) { }

        public override async Task AddAsync(Residente entity)
        {
            if (string.IsNullOrWhiteSpace(entity.NombreCompleto))
                throw new ResidenteException("El nombre completo del residente es obligatorio.");

            if (string.IsNullOrWhiteSpace(entity.UnidadVivienda))
                throw new ResidenteException("La unidad de vivienda es obligatoria.");

            await base.AddAsync(entity);
        }

        public async Task<Residente?> GetByDocumentoAsync(string documento) =>
            await _dbSet.FirstOrDefaultAsync(r => !r.Eliminado && r.DocumentoIdentidad == documento);
    }
}