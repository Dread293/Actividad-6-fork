using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad_6.Models;

[Table("juegos")]
public class Juego
{
    [Key]
    [Column("id_juego")]
    public int IdJuego { get; set; }

    [Required, MaxLength(50)]
    [Column("codigo")]
    public string Codigo { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    [Column("nombre_juego")]
    public string NombreJuego { get; set; } = string.Empty;

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [Column("activo")]
    public bool Activo { get; set; } = true;
}