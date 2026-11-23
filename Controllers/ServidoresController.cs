using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Actividad_6.Data;
using Actividad_6.Models;

namespace Actividad_6.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ServidoresController : ControllerBase
{
    private readonly AppDbContext _context;
    public ServidoresController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _context.Servidores.ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _context.Servidores.FindAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Servidor servidor)
    {
        servidor.FechaCreacion = DateTime.UtcNow;
        _context.Servidores.Add(servidor);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = servidor.IdServidor }, servidor);
    }
    // PUT: api/Servidores/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Servidor servidor)
    {
        if (id != servidor.IdServidor)
            return BadRequest(new { mensaje = "El ID no coincide." });

        var existente = await _context.Servidores
            .FirstOrDefaultAsync(s => s.IdServidor == id && !s.Eliminado);

        if (existente == null)
            return NotFound(new { mensaje = "Servidor no encontrado." });

        _context.Entry(existente).CurrentValues.SetValues(servidor);

        // Mantener la fecha original de creación.
        existente.FechaCreacion = existente.FechaCreacion;
        existente.Eliminado = false;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Servidores/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var servidor = await _context.Servidores
            .FirstOrDefaultAsync(s => s.IdServidor == id && !s.Eliminado);

        if (servidor == null)
            return NotFound(new { mensaje = "Servidor no encontrado." });

        // Soft Delete: marcar como eliminado sin borrar de la BD.
        servidor.Eliminado = true;

        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Servidor eliminado correctamente." });
    }
}