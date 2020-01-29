using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Defiance.Bolton.Infrastructure.Data.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EletronicTaxInvoice",
                columns: table => new
                {
                    AccessKey = table.Column<string>(nullable: false),
                    DateIssued = table.Column<DateTime>(nullable: false),
                    IssuerTaxId = table.Column<string>(nullable: true),
                    RecipientTaxId = table.Column<string>(nullable: true),
                    TotalAmount = table.Column<decimal>(type: "DECIMAL(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EletronicTaxInvoice", x => x.AccessKey);
                });

            migrationBuilder.CreateTable(
                name: "ImportHistory",
                columns: table => new
                {
                    ImportHistoryId = table.Column<Guid>(nullable: false),
                    DocumentType = table.Column<int>(nullable: false),
                    CurrentPage = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateCompleted = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportHistory", x => x.ImportHistoryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EletronicTaxInvoice");

            migrationBuilder.DropTable(
                name: "ImportHistory");
        }
    }
}
