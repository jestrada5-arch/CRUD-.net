using Microsoft.EntityFrameworkCore;

namespace ApiEmpresa.Models
{
    // Conexión a la base de datos
    public class Conexiones : DbContext
    {
        public Conexiones(DbContextOptions<Conexiones> options) : base(options)
        {
        }

        public DbSet<Clientes> Clientes { get; set; } = null!;
    }
}
