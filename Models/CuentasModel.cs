using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DivisasAPI.Models;

[Table("Cuentas")]
public class CuentasModel
{
    [Key]
    public int CuentaId { get; set; }
    public string? Descripcion { get; set; }
    public int? Saldo { get; set; }
    public string? Tipo { get; set; }
    public DateTime? Fecha { get; set; }
    public bool? Estado { get; set; }
}