using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Actividad_6.Data;
using Actividad_6.Models;

namespace Actividad_6.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class JuegosController : ControllerBase
{
    private readonly AppDbContext _context;
    public JuegosController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _context.Juegos.ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _context.Juegos.FindAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Juego juego)
    {
        _context.Juegos.Add(juego);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = juego.IdJuego }, juego);
    }
    // PUT: api/Juegos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutJuego(int id, Juego juego)
    {
        if (id != juego.Id)
            return BadRequest(new { mensaje = "El ID no coincide." });

        var existente = await _context.Juegos
            .FirstOrDefaultAsync(j => j.Id == id && !j.Eliminado);

        if (existente == null)
            return NotFound(new { mensaje = "Juego no encontrado." });

        // Actualizar los datos del juego.
        _context.Entry(existente).CurrentValues.SetValues(juego);

        // Evitar que el registro sea marcado como eliminado.
        existente.Eliminado = false;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Juegos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJuego(int id)
    {
        var juego = await _context.Juegos
            .FirstOrDefaultAsync(j => j.Id == id && !j.Eliminado);

        if (juego == null)
            return NotFound(new { mensaje = "Juego no encontrado." });

        // Soft Delete: no se elimina físicamente de la base de datos.
        juego.Eliminado = true;

        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Juego eliminado correctamente." });
    }
}