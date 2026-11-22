using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad_6.Models;

[Table("configuracion_servidores")]
public class ConfiguracionServidor
{
    [Key, ForeignKey("Servidor")]
    [Column("id_servidor")]
    public int IdServidor { get; set; }

    public Servidor? Servidor { get; set; }

    [Required, MaxLength(100)]
    [Column("nombre_mundo")]
    public string NombreMundo { get; set; } = "world";

    [Column("tamano_mundo")]
    public int TamanoMundo { get; set; } = 2000;

    [MaxLength(30)]
    [Column("dificultad")]
    public string Dificultad { get; set; } = "normal";

    [Column("max_jugadores")]
    public int MaxJugadores { get; set; } = 10;

    [Column("contrasena_cifrada")]
    public string? ContrasenaCifrada { get; set; }

    [Column("seguro")]
    public bool Seguro { get; set; } = true;

    [Column("activo")]
    public bool Activo { get; set; } = true;
}