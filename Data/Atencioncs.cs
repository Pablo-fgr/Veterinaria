using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Veterinaria.Data
{
    public class Atencion
    {
        [Key]
        public int IdAtencion { get; set; }

        [Required(ErrorMessage = "La fecha de atención es obligatoria.")]
        public DateTime FechaAtencion { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El tipo de servicio es obligatorio.")]
        public string TipoServicio { get; set; } = string.Empty; // Ej: "Consulta", "Vacunación", "Cirugía"

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0.")]
        public decimal Monto { get; set; }

        public string? Observaciones { get; set; }

        // --- RELACIÓN CON MASCOTA ---
        [Required]
        public int IdMascota { get; set; }

        // Propiedad de navegación
        [ForeignKey("IdMascota")]
        public virtual Mascota Mascota { get; set; } = null!;
    }
}