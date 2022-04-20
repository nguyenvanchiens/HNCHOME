using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HNCHOME.Migrations
{
    public partial class adding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoodsType",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Quantum",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ServiceType",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Customers");

            migrationBuilder.CreateTable(
                name: "ServiceInfos",
                columns: table => new
                {
                    ServiceId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ServiceTypeName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GoodsType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Weight = table.Column<float>(type: "float", nullable: false),
                    Size = table.Column<float>(type: "float", nullable: false),
                    Quantum = table.Column<float>(type: "float", nullable: false),
                    Quantity = table.Column<float>(type: "float", nullable: false),
                    IsChecked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceInfos", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_ServiceInfos_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInfos_CustomerId",
                table: "ServiceInfos",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceInfos");

            migrationBuilder.AddColumn<string>(
                name: "GoodsType",
                table: "Customers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<float>(
                name: "Quantity",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Quantum",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "ServiceType",
                table: "Customers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<float>(
                name: "Size",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
