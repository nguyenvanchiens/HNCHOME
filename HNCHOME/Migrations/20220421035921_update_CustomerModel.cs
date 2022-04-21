using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HNCHOME.Migrations
{
    public partial class update_CustomerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OtherRequest",
                table: "Customers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherRequest",
                table: "Customers");
        }
    }
}
