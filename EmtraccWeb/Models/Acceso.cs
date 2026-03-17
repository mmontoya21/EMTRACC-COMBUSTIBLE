using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmtraccWeb.Models;

[Table("accesos")]
public class Acceso
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre")]
    public string Nombre { get; set; } = "";

    [Column("apellido")]
    public string Apellido { get; set; } = "";

    [Column("usuario")]
    public string Usuario { get; set; } = "";

    [Column("clave")]
    public string Clave { get; set; } = "";

    [Column("tipo")]
    public string Tipo { get; set; } = "";

    [Column("status")]
    public string Status { get; set; } = "";

    [Column("fecha")]
    public DateTime? Fecha { get; set; }

    [Column("permisos")]
    public string? Permisos { get; set; }
}
