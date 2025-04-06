using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_PDS.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CondominioId",
                table: "Utilizadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CodigoPostal",
                columns: table => new
                {
                    CP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Localidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigoPostal", x => x.CP);
                });

            migrationBuilder.CreateTable(
                name: "Condominios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Morada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CP = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Condominios_CodigoPostal_CP",
                        column: x => x.CP,
                        principalTable: "CodigoPostal",
                        principalColumn: "CP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Utilizadores_CondominioId",
                table: "Utilizadores",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Condominios_CP",
                table: "Condominios",
                column: "CP");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilizadores_Condominios_CondominioId",
                table: "Utilizadores",
                column: "CondominioId",
                principalTable: "Condominios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilizadores_Condominios_CondominioId",
                table: "Utilizadores");

            migrationBuilder.DropTable(
                name: "Condominios");

            migrationBuilder.DropTable(
                name: "CodigoPostal");

            migrationBuilder.DropIndex(
                name: "IX_Utilizadores_CondominioId",
                table: "Utilizadores");

            migrationBuilder.DropColumn(
                name: "CondominioId",
                table: "Utilizadores");
        }
    }
}
