using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DivisasAPI.Models;

[Table("Operaciones")]
public class OperacionesModels
{        
    [Key]
    public int operacionesId { get; set; }
    public DateTime? Fecha { get; set; }
    public string? tipoOperacion { get; set; }
    public int? Monto { get; set; }

    [ForeignKey("Cuentas")]
    public int CuentaId { get; set; }
    public CuentasModel? cuentasModel { get; set; }
    
    [ForeignKey("Transacciones")]
    public int transaccionesId { get; set; }
    public TransacionModel? transacionModel { get; set; }
}
