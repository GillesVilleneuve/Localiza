using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Localiza.Repositorio.Migrations
{
    public partial class PrimeiraVersaoBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Placa = table.Column<string>(maxLength: 8, nullable: false),
                    CodChassi = table.Column<string>(maxLength: 20, nullable: false),
                    CodRenavan = table.Column<string>(maxLength: 12, nullable: false),
                    Marca = table.Column<string>(maxLength: 20, nullable: false),
                    Modelo = table.Column<string>(maxLength: 20, nullable: false),
                    Ano = table.Column<int>(maxLength: 4, nullable: false),
                    NomeArquivo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
