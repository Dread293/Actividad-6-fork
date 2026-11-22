using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad_6.Models;

[Table("version_juegos")]
public class VersionJuego
{
    [Key]
    [Column("id_version")]
    public int IdVersion { get; set; }

    [Column("id_juego")]
    public int IdJuego { get; set; }

    [ForeignKey("IdJuego")]
    public Juego? Juego { get; set; }

    [Required, MaxLength(50)]
    [Column("version")]
    public string Version { get; set; } = string.Empty;

    [Required, MaxLength(150)]
    [Column("etiqueta_imagen")]
    public string EtiquetaImagen { get; set; } = string.Empty;

    [Column("activo")]
    public bool Activo { get; set; } = true;
}