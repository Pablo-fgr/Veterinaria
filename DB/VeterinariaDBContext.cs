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
        // POR ESTAS
        public DbSet<Owner> Owners { get; set; } = null!;
        public DbSet<Mascota> Mascotas { get; set; } = null!;
        public DbSet<Atencion> Atenciones { get; set; } = null!;
        // Aquí podrías agregar
        // public DbSet<Cita> Citas { get; set; }
        // public DbSet<HistoriaClinica> HistoriasClinicas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definir la relación Uno a Muchos (Dueño -> Mascotas)
            modelBuilder.Entity<Mascota>()
                .HasOne(m => m.Owner)
                .WithMany(d => d.Mascotas)
                .HasForeignKey(m => m.IdOwner);

            // Definir la relación Uno a Muchos (Mascota -> Atenciones)
            modelBuilder.Entity<Atencion>()
                .HasOne(a => a.Mascota)
                .WithMany()
                .HasForeignKey(a => a.IdMascota);

            // Configurar precisión y escala para el campo Monto
            modelBuilder.Entity<Atencion>()
                .Property(a => a.Monto)
                .HasPrecision(18, 2); // 18 dígitos totales, 2 decimales

            // (Opcional) Agregar datos de ejemplo si quieres
            // modelBuilder.Entity<Dueño>().HasData(
            //    new Dueño { IdDueño = 1, NombreCompleto = "Juan Perez", Dni = "30123456", ... }
            // );
        }
    }
}