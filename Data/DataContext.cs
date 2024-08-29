using api_debt_collector.Models;
using Microsoft.EntityFrameworkCore;

namespace api_debt_collector.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
        }
        public DbSet<DebitModel> DebitDataModel { get; set; }
        public DbSet<ParcelamentoModels> ParcelamentoModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DebitModel>()
                .HasMany(d => d.ModeloDeParcelamento)
                .WithOne(p => p.DebitDataModel)
                .HasForeignKey(p => p.id_debit);
        }
    }
}
