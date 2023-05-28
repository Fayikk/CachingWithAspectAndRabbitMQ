using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RabbitMQExample.Migrations
{
    public partial class BasketRevize1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Decimal",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Decimal",
                table: "Orders",
                newName: "Price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "Decimal");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Orders",
                newName: "Decimal");
        }
    }
}
