using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HNCHOME.Migrations
{
    public partial class update_ServiceInfoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ServiceInfos");

            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "ServiceInfos");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ServiceInfos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ServiceInfos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ServiceInfos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ServiceInfos",
                type: "datetime(6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ServiceInfos");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ServiceInfos");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ServiceInfos");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ServiceInfos");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "ServiceInfos",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "ServiceInfos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
