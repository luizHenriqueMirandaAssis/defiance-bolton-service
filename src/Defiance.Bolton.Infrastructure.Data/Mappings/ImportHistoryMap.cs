using Defiance.Bolton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Defiance.Bolton.Infrastructure.Data.Mappings
{
    public class ImportHistoryMap : IEntityTypeConfiguration<ImportHistory>
    {
        public void Configure(EntityTypeBuilder<ImportHistory> builder)
        {
            builder.ToTable("ImportHistory");
            builder.HasKey(e => e.ImportHistoryId);
            builder.Property(e => e.DocumentType);
            builder.Property(e => e.CurrentPage);
            builder.Property(e => e.DateCreated);
            builder.Property(e => e.DateCreated);
        }
    }
}
