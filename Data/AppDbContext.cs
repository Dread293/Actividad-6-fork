using Microsoft.EntityFrameworkCore;
using Actividad_6.Models;

namespace Actividad_6.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Juego> Juegos { get; set; }
    public DbSet<VersionJuego> VersionJuegos { get; set; }
    public DbSet<Servidor> Servidores { get; set; }
    public DbSet<ConfiguracionServidor> ConfiguracionServidores { get; set; }
}