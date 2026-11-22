using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad_6.Models;

[Table("servidores")]
public class Servidor
{
    [Key]
    [Column("id_servidor")]
    public int IdServidor { get; set; }

    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("id_version")]
    public int IdVersion { get; set; }

    [ForeignKey("IdVersion")]
    public VersionJuego? VersionJuego { get; set; }

    [Required, MaxLength(100)]
    [Column("nombre_servidor")]
    public string NombreServidor { get; set; } = string.Empty;

    [MaxLength(100)]
    [Column("id_contenedor")]
    public string? IdContenedor { get; set; }

    [MaxLength(50)]
    [Column("estado_requerido")]
    public string EstadoRequerido { get; set; } = "detenido";

    [MaxLength(50)]
    [Column("estado_actual")]
    public string EstadoActual { get; set; } = "detenido";

    [Column("fecha_creacion")]
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    [Column("fecha_actualizacion")]
    public DateTime? FechaActualizacion { get; set; }

    [Column("fecha_eliminacion")]
    public DateTime? FechaEliminacion { get; set; }
}