using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiEmpresa.Models
{
    // Representa la tabla Clientes de MySQL
    public class Clientes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_cliente { get; set; }

        [StringLength(13)]
        public string CUI { get; set; } = string.Empty;

        [StringLength(15)]
        public string NIT { get; set; } = string.Empty;

        [StringLength(60)]
        public string nombres { get; set; } = string.Empty;

        [StringLength(60)]
        public string apellidos { get; set; } = string.Empty;

        [StringLength(150)]
        public string direccion { get; set; } = string.Empty;

        [StringLength(12)]
        public string Telefono { get; set; } = string.Empty;

        public DateTime fecha_nacimiento { get; set; }
    }
}
