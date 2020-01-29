using Defiance.Bolton.Domain.Entities;
using Defiance.Bolton.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Defiance.Bolton.Infrastructure.Data.Context
{
    public class DefianceBoltonContext : DbContext
    {
        public DefianceBoltonContext(DbContextOptions<DefianceBoltonContext> options) : base(options) { }

        public virtual DbSet<EletronicTaxInvoice> EletronicTaxInvoices { get; set; }
        public virtual DbSet<ImportHistory> ImportHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(DefianceBoltonContext).Assembly);
            modelBuilder.ApplyConfiguration(new EletronicTaxInvoiceMap());
            modelBuilder.ApplyConfiguration(new ImportHistoryMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
