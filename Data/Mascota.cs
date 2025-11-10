using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        // Clave foránea para el Owner
        [Required]
        public int IdOwner { get; set; }

        // Propiedad de navegación
        [ForeignKey("IdOwner")]
        public virtual Owner Owner { get; set; } = null!;
    }
}