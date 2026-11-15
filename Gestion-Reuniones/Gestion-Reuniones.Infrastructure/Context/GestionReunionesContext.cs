using System;

using Gestion_Reuniones.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Reuniones.Infrastructure.Context
{
    public class GestionReunionesContext : DbContext
    {
        public GestionReunionesContext(DbContextOptions<GestionReunionesContext> options)
            : base(options)
        {
        }

        public DbSet<Residente> Residentes { get; set; }
        public DbSet<Reunion> Reuniones { get; set; }
        public DbSet<Acuerdo> Acuerdos { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Evitar cascadas múltiples en relaciones con Residente
            modelBuilder.Entity<Acuerdo>()
                .HasOne(a => a.ResidenteResponsable)
                .WithMany(r => r.AcuerdosResponsable)
                .HasForeignKey(a => a.ResidenteResponsableId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Asistencia>()
                .HasOne(a => a.Residente)
                .WithMany(r => r.Asistencias)
                .HasForeignKey(a => a.ResidenteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}