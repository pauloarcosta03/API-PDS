using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_PDS.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GestorCondominioId",
                table: "Utilizadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ContactosEmergencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telemovel = table.Column<int>(type: "int", nullable: false),
                    CondominioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactosEmergencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactosEmergencia_Condominios_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GestoresCondominio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CondominioId = table.Column<int>(type: "int", nullable: false),
                    UtilizadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GestoresCondominio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GestoresCondominio_Condominios_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GestoresCondominio_Utilizadores_UtilizadorId",
                        column: x => x.UtilizadorId,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Utilizadores_GestorCondominioId",
                table: "Utilizadores",
                column: "GestorCondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactosEmergencia_CondominioId",
                table: "ContactosEmergencia",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_GestoresCondominio_CondominioId",
                table: "GestoresCondominio",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_GestoresCondominio_UtilizadorId",
                table: "GestoresCondominio",
                column: "UtilizadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilizadores_GestoresCondominio_GestorCondominioId",
                table: "Utilizadores",
                column: "GestorCondominioId",
                principalTable: "GestoresCondominio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilizadores_GestoresCondominio_GestorCondominioId",
                table: "Utilizadores");

            migrationBuilder.DropTable(
                name: "ContactosEmergencia");

            migrationBuilder.DropTable(
                name: "GestoresCondominio");

            migrationBuilder.DropIndex(
                name: "IX_Utilizadores_GestorCondominioId",
                table: "Utilizadores");

            migrationBuilder.DropColumn(
                name: "GestorCondominioId",
                table: "Utilizadores");
        }
    }
}
