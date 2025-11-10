using Microsoft.EntityFrameworkCore;
using Veterinaria.Data;

namespace Veterinaria.DB
{
    public class VeterinariaDBContext : DbContext
    {
        // Constructor necesario para la inyección de dependencias
        public VeterinariaDBContext(DbContextOptions<VeterinariaDBContext> options)
            : base(options)
        {
        }

        // --- Tablas de la Base de Datos ---
        public DbSet<Dueño> Dueños { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        // Aquí podrías agregar
        // public DbSet<Cita> Citas { get; set; }
        // public DbSet<HistoriaClinica> HistoriasClinicas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definir la relación Uno a Muchos (Dueño -> Mascotas)
            modelBuilder.Entity<Mascota>()
                .HasOne(m => m.Dueño)
                .WithMany(d => d.Mascotas)
                .HasForeignKey(m => m.IdDueño);

            // (Opcional) Agregar datos de ejemplo si quieres
            // modelBuilder.Entity<Dueño>().HasData(
            //    new Dueño { IdDueño = 1, NombreCompleto = "Juan Perez", Dni = "30123456", ... }
            // );
        }
    }
}