using System.ComponentModel.DataAnnotations;

namespace ApiEmpresa.Models
{
    // Datos que recibe la API en POST y PUT (con validaciones).
    // No incluye id_cliente: el id lo genera la base de datos o viene en la URL.
    public class ClienteInputDto : IValidatableObject
    {
        [Required, RegularExpression(@"^\d{13}\z", ErrorMessage = "El CUI debe tener 13 dígitos.")]
        public string CUI { get; set; } = string.Empty;

        [Required, StringLength(15),
         RegularExpression(@"^\d{1,13}-?[0-9Kk]\z", ErrorMessage = "NIT inválido (ej. 123456-7).")]
        public string NIT { get; set; } = string.Empty;

        [Required, StringLength(60),
         RegularExpression(@"^\p{L}[\p{L} .'\-]*\z", ErrorMessage = "Los nombres solo admiten letras.")]
        public string nombres { get; set; } = string.Empty;

        [Required, StringLength(60),
         RegularExpression(@"^\p{L}[\p{L} .'\-]*\z", ErrorMessage = "Los apellidos solo admiten letras.")]
        public string apellidos { get; set; } = string.Empty;

        [StringLength(150),
         RegularExpression(@"^[\p{L}\p{N} .,#°/\-]*\z", ErrorMessage = "La dirección contiene caracteres no permitidos.")]
        public string? direccion { get; set; }

        [RegularExpression(@"^\d{8,12}\z", ErrorMessage = "El teléfono debe tener entre 8 y 12 dígitos.")]
        public string? Telefono { get; set; }

        [Required]
        public DateTime fecha_nacimiento { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (fecha_nacimiento < new DateTime(1900, 1, 1) || fecha_nacimiento > DateTime.Today)
            {
                yield return new ValidationResult(
                    "La fecha de nacimiento no es válida.",
                    new[] { nameof(fecha_nacimiento) });
            }
        }
    }
}
