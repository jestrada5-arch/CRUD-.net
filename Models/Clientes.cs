using System;

using System.ComponentModel.DataAnnotations;

namespace ApiEmpresa.Models
{
    public class Clientes
    {
        [Key]
        public int id_cliente { get; set; }
        
        [StringLength(13)]
        public string CUI { get; set; }
        
        [StringLength(15)]
        public string NIT { get; set; }
        
        [StringLength(60)]
        public string nombres { get; set; }
        
        [StringLength(60)]
        public string apellidos { get; set; }
        
        [StringLength(150)]
        public string direccion { get; set; }
        
        [StringLength(12)]
        public string Telefono { get; set; }
        
        public DateTime fecha_nacimiento { get; set; }
    }
}