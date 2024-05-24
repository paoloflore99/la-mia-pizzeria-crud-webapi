using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace la_mia_pizzeria_static.Migrations
{
    public partial class UpdateIngredientiPizza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categoria",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categoria",
                newName: "id");
        }
    }
}
