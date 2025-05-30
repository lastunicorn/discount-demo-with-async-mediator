using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiscountDemo.Adapter.EfDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("2fd3575d-e43e-49b1-b05b-16aa2947d1ea"), "John Doe", 1 },
                    { new Guid("3c2963ab-0424-4e3d-8aef-ab0c813a08cc"), "John Doe", 4 },
                    { new Guid("9625e3f2-31fa-4d3a-81ab-48456372e943"), "John Doe", 3 },
                    { new Guid("a643cefd-60ff-44a3-b567-de7235525257"), "John Doe", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
