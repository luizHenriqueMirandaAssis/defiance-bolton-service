﻿// <auto-generated />
using System;
using Defiance.Bolton.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Defiance.Bolton.Infrastructure.Data.Migrations
{
    [DbContext(typeof(DefianceBoltonContext))]
    partial class DefianceBoltonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Defiance.Bolton.Domain.Entities.EletronicTaxInvoice", b =>
                {
                    b.Property<string>("AccessKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateIssued")
                        .HasColumnType("datetime2");

                    b.Property<string>("IssuerTaxId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipientTaxId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("DECIMAL(18,6)");

                    b.HasKey("AccessKey");

                    b.ToTable("EletronicTaxInvoice");
                });

            modelBuilder.Entity("Defiance.Bolton.Domain.Entities.ImportHistory", b =>
                {
                    b.Property<Guid>("ImportHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CurrentPage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCompleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("DocumentType")
                        .HasColumnType("int");

                    b.HasKey("ImportHistoryId");

                    b.ToTable("ImportHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
