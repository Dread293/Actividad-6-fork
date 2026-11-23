
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad_6.Models;

[Table("usuarios")]
public class Usuario
{
    [Key]
    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("id_rol")]
    public int IdRol { get; set; }

    [Required, MaxLength(100)]
    [Column("nombre_usuario")]
    public string NombreUsuario { get; set; } = string.Empty;

    [Required, MaxLength(150)]
    [Column("correo")]
    public string Correo { get; set; } = string.Empty;

    [Required, MaxLength(255)]
    [Column("contrasena_hash")]
    public string ContrasenaHash { get; set; } = string.Empty;

    [Required, MaxLength(30)]
    [Column("estado")]
    public string Estado { get; set; } = "activo";

    [Column("fecha_creacion")]
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    public ICollection<EventoServidor> Eventos { get; set; } = new List<EventoServidor>();
}
