using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroFlow.Infrastructure.Data.Migrations.Budget
{
    public partial class InitialMigration_BudgetDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Budget");

            migrationBuilder.CreateTable(
                name: "BudgetItemTypes",
                schema: "Budget",
                columns: table => new
                {
                    BudgetClass = table.Column<string>(maxLength: 10, nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Notes = table.Column<string>(maxLength: 1000, nullable: true),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BudgetItems",
                schema: "Budget",
                columns: table => new
                {
                    Amount = table.Column<decimal>(nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Notes = table.Column<string>(maxLength: 1000, nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Type_Id = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetItems_BudgetItemTypes_Type_Id",
                        column: x => x.Type_Id,
                        principalSchema: "Budget",
                        principalTable: "BudgetItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetItems_Type_Id",
                schema: "Budget",
                table: "BudgetItems",
                column: "Type_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetItems",
                schema: "Budget");

            migrationBuilder.DropTable(
                name: "BudgetItemTypes",
                schema: "Budget");
        }
    }
}
