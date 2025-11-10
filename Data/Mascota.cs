using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.Data
{
    public class Mascota
    {
        [Key]
        public int IdMascota { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La especie es obligatoria.")]
        public string Especie { get; set; } = string.Empty; // Ej: "Perro", "Gato"

        public string? Raza { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        // --- RELACIÓN ---
        // Clave foránea para el Dueño
        [Required]
        public int IdDueño { get; set; }

        // Propiedad de navegación
        [ForeignKey("IdDueño")]
        public virtual Dueño Dueño { get; set; }
    }
}