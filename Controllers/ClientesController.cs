using ApiEmpresa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpresa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly Conexiones _context;

        public ClientesController(Conexiones context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        {
            return await _context.Clientes.AsNoTracking().ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Clientes>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();
            return cliente;
        }

        // POST: api/Clientes
        [HttpPost]
        public async Task<ActionResult<Clientes>> PostCliente(ClienteInputDto dto)
        {
            var cliente = new Clientes();
            Mapear(dto, cliente);

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.id_cliente }, cliente);
        }

        // PUT: api/Clientes/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutCliente(int id, ClienteInputDto dto)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();

            Mapear(dto, cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private static void Mapear(ClienteInputDto dto, Clientes cliente)
        {
            cliente.CUI = dto.CUI;
            cliente.NIT = dto.NIT;
            cliente.nombres = dto.nombres;
            cliente.apellidos = dto.apellidos;
            cliente.direccion = dto.direccion ?? string.Empty;
            cliente.Telefono = dto.Telefono ?? string.Empty;
            cliente.fecha_nacimiento = dto.fecha_nacimiento;
        }
    }
}
