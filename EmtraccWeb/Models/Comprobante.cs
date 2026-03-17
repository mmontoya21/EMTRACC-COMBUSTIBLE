using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmtraccWeb.Models;

[Table("comprobante")]
public class Comprobante
{
    [Key]
    [Column("idcprbnt")]
    public int Idcprbnt { get; set; }

    [Column("nCompro")]
    public string? NCompro { get; set; }

    [Column("nBoleta")]
    public string? NBoleta { get; set; }

    [Column("fecha")]
    public DateTime? Fecha { get; set; }

    [Column("nombDesp")]
    public string? NombDesp { get; set; }

    [Column("propCbz")]
    public string? PropCbz { get; set; }

    [Column("placaCbz")]
    public string? PlacaCbz { get; set; }

    [Column("periodo")]
    public string? Periodo { get; set; }

    [Column("semana")]
    public string? Semana { get; set; }

    [Column("ruta")]
    public string? Ruta { get; set; }

    [Column("galDesp")]
    public decimal? GalDesp { get; set; }

    [Column("valor")]
    public decimal? Valor { get; set; }

    [Column("total")]
    public decimal? Total { get; set; }

    [Column("nConte")]
    public string? NConte { get; set; }

    [Column("nombCond")]
    public string? NombCond { get; set; }

    [Column("proxSem")]
    public string? ProxSem { get; set; }

    [Column("codiProp")]
    public string? CodiProp { get; set; }

    [Column("anulado")]
    public bool Anulado { get; set; }
}
