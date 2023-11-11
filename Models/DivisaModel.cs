using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DivisasAPI.Models
{
    [Table("Divisas")]
    public class DivisaModel
    {
        [Key]
        public int DivisaId { get; set; }
        public string? NombreDivisa { get; set; }
        public int? valorDivisa { get; set; }
    }
}
