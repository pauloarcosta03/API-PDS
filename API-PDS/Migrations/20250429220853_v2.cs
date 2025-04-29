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
            migrationBuilder.DropForeignKey(
                name: "FK_Post_GestoresCondominio_GestorCondominioId",
                table: "Post");

            migrationBuilder.AlterColumn<int>(
                name: "GestorCondominioId",
                table: "Post",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_GestoresCondominio_GestorCondominioId",
                table: "Post",
                column: "GestorCondominioId",
                principalTable: "GestoresCondominio",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_GestoresCondominio_GestorCondominioId",
                table: "Post");

            migrationBuilder.AlterColumn<int>(
                name: "GestorCondominioId",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_GestoresCondominio_GestorCondominioId",
                table: "Post",
                column: "GestorCondominioId",
                principalTable: "GestoresCondominio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
