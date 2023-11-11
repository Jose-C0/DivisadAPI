using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DivisasAPI.Models
{
    [Table("Transacciones")]
    public class TransacionModel
    {
        [Key]
        public int TransaccionId { get; set; }
        [ForeignKey("Divisas")]
        public int? DivisaId { get; set; }
        public DivisaModel? divisaModel { get; set; }
    }
}
