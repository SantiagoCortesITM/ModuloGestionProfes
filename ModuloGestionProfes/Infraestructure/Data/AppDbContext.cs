using Microsoft.EntityFrameworkCore;
using ModuloGestionProfes.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ModuloGestionProfes.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Profesor> Profesores => Set<Profesor>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.ToTable("Profesores");

                entity.HasKey(p => p.Id);

                entity.Property(p => p.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.Email)
                    .IsRequired();

                entity.Property(p => p.Especialidad)
                    .IsRequired(false);

                entity.Property(p => p.FechaContratacion)
                    .IsRequired();

                entity.HasIndex(p => p.Email).IsUnique();
            });
        }
    }
}
