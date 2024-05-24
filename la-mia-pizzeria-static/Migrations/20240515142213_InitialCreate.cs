using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace la_mia_pizzeria_static.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizze",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlFoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezzo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizze", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizze");
        }
    }
}
