using Defiance.Bolton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Defiance.Bolton.Infrastructure.Data.Mappings
{
    public class EletronicTaxInvoiceMap : IEntityTypeConfiguration<EletronicTaxInvoice>
    {
        public void Configure(EntityTypeBuilder<EletronicTaxInvoice> builder)
        {
            builder.ToTable("EletronicTaxInvoice");

            builder.HasKey(e => e.AccessKey);
            builder.Property(e => e.DateIssued);
            builder.Property(e => e.IssuerTaxId);
            builder.Property(e => e.RecipientTaxId);
            builder.Property(e => e.TotalAmount).HasColumnType("DECIMAL(18,6)");
        }
    }
}
