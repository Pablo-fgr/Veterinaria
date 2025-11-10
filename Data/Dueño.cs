using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Veterinaria.Data
{
    public class Dueño
    {
        [Key] // Es buena práctica definir la Key
        public int IdDueño { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required(ErrorMessage = "El DNI es obligatorio.")]
        // Se corrige la validación, DNI en Arg. es numérico pero se trata como string para no perder ceros
        [StringLength(8, MinimumLength = 7, ErrorMessage = "El DNI debe tener entre 7 y 8 dígitos.")]
        public string Dni { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateTime? FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El domicilio es obligatorio.")]
        public string Domicilio { get; set; } = string.Empty;

        [Required(ErrorMessage = "El sexo es obligatorio.")]
        public string Sexo { get; set; } = string.Empty;

        // --- NUEVO ---
        // Relación: Un dueño puede tener muchas mascotas
        public virtual ICollection<Mascota> Mascotas { get; set; } = new List<Mascota>();
    }
}