
using Actividad_6.Data;
using Actividad_6.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad_6.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PuertosServidoresController : ControllerBase
{
    private readonly AppDbContext _context;

    public PuertosServidoresController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var puertos = await _context.PuertosServidores
            .AsNoTracking()
            .ToListAsync();

        return Ok(puertos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var puerto = await _context.PuertosServidores
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.IdPuerto == id);

        if (puerto == null)
            return NotFound(new { mensaje = "Puerto no encontrado" });

        return Ok(puerto);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(PuertoServidor puerto)
    {
        _context.PuertosServidores.Add(puerto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(ObtenerPorId),
            new { id = puerto.IdPuerto },
            puerto);
    }
}