
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad_6.Models;

[Table("puertos_servidores")]
public class PuertoServidor
{
    [Key]
    [Column("id_puerto")]
    public int IdPuerto { get; set; }

    [Column("id_servidor")]
    public int IdServidor { get; set; }

    [Column("puerto_host")]
    public int PuertoHost { get; set; }

    [Column("puerto_contenedor")]
    public int PuertoContenedor { get; set; }

    [Column("activo")]
    public bool Activo { get; set; } = true;

    [ForeignKey(nameof(IdServidor))]
    public Servidor? Servidor { get; set; }
}