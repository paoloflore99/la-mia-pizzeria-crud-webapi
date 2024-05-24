using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace la_mia_pizzeria_static.Migrations
{
    public partial class UpdateIngredienti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredientis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientiPizze",
                columns: table => new
                {
                    IngredientisId = table.Column<int>(type: "int", nullable: false),
                    PizzeListID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientiPizze", x => new { x.IngredientisId, x.PizzeListID });
                    table.ForeignKey(
                        name: "FK_IngredientiPizze_Ingredientis_IngredientisId",
                        column: x => x.IngredientisId,
                        principalTable: "Ingredientis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientiPizze_Pizze_PizzeListID",
                        column: x => x.PizzeListID,
                        principalTable: "Pizze",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientiPizze_PizzeListID",
                table: "IngredientiPizze",
                column: "PizzeListID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientiPizze");

            migrationBuilder.DropTable(
                name: "Ingredientis");
        }
    }
}
