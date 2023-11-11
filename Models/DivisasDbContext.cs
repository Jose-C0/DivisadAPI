using DivisasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DivisadAPI.Models
{
    public class DivisasDbContext : DbContext
    {
        public DivisasDbContext(DbContextOptions<DivisasDbContext> options) 
        : base(options)
        {            
        }
        public DbSet<DivisaModel> Divisas { get; set; }
        public DbSet<TransacionModel> Transacciones { get; set; }
        public DbSet<OperacionesModels> Operaciones { get; set; }
        public DbSet<CuentasModel> Cuentas { get; set; }
    }
}
