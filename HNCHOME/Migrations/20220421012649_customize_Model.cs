using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HNCHOME.Migrations
{
    public partial class customize_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoodsType",
                table: "ServiceInfos");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ServiceInfos");

            migrationBuilder.DropColumn(
                name: "Quantum",
                table: "ServiceInfos");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "ServiceInfos");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "ServiceInfos");

            migrationBuilder.RenameColumn(
                name: "ServiceInfos",
                table: "Customers",
                newName: "Size");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "ServiceInfos",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

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

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ServiceInfos");

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
                name: "Weight",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Customers",
                newName: "ServiceInfos");

            migrationBuilder.AddColumn<string>(
                name: "GoodsType",
                table: "ServiceInfos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<float>(
                name: "Quantity",
                table: "ServiceInfos",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Quantum",
                table: "ServiceInfos",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "ServiceInfos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "ServiceInfos",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
