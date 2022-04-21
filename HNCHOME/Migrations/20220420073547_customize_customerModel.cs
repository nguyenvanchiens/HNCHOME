using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HNCHOME.Migrations
{
    public partial class customize_customerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInfos_Customers_CustomerId",
                table: "ServiceInfos");

            migrationBuilder.DropIndex(
                name: "IX_ServiceInfos_CustomerId",
                table: "ServiceInfos");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ServiceInfos");

            migrationBuilder.AddColumn<string>(
                name: "ServiceInfos",
                table: "Customers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceInfos",
                table: "Customers");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "ServiceInfos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInfos_CustomerId",
                table: "ServiceInfos",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInfos_Customers_CustomerId",
                table: "ServiceInfos",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");
        }
    }
}
