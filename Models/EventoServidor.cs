
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad_6.Models;

[Table("evento_servidores")]
public class EventoServidor
{
    [Key]
    [Column("id_evento")]
    public int IdEvento { get; set; }

    [Column("id_servidor")]
    public int IdServidor { get; set; }

    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Required, MaxLength(50)]
    [Column("tipo_evento")]
    public string TipoEvento { get; set; } = string.Empty;

    [Required, MaxLength(30)]
    [Column("resultado")]
    public string Resultado { get; set; } = string.Empty;

    [Column("detalles")]
    public string? Detalles { get; set; }

    [Column("fecha")]
    public DateTime Fecha { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(IdServidor))]
    public Servidor? Servidor { get; set; }

    [ForeignKey(nameof(IdUsuario))]
    public Usuario? Usuario { get; set; }
}
