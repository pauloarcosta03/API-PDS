using System;
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
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtilizadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nif = table.Column<int>(type: "int", nullable: false),
                    NPorta = table.Column<int>(type: "int", nullable: false),
                    CondominioId = table.Column<int>(type: "int", nullable: true),
                    GestorCondominioId = table.Column<int>(type: "int", nullable: true),
                    LoginId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utilizadores_Condominios_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Utilizadores_GestoresCondominio_GestorCondominioId",
                        column: x => x.GestorCondominioId,
                        principalTable: "GestoresCondominio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Utilizadores_Login_LoginId",
                        column: x => x.LoginId,
                        principalTable: "Login",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    Descricao = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtilizadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.Descricao);
                    table.ForeignKey(
                        name: "FK_Contactos_Utilizadores_UtilizadorId",
                        column: x => x.UtilizadorId,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resposta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UtilizadorId = table.Column<int>(type: "int", nullable: false),
                    GestorCondominioId = table.Column<int>(type: "int", nullable: true),
                    CondominioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidencias_Condominios_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidencias_GestoresCondominio_GestorCondominioId",
                        column: x => x.GestorCondominioId,
                        principalTable: "GestoresCondominio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Incidencias_Utilizadores_UtilizadorId",
                        column: x => x.UtilizadorId,
                        principalTable: "Utilizadores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumLikes = table.Column<int>(type: "int", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aceite = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtilizadorId = table.Column<int>(type: "int", nullable: false),
                    GestorCondominioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_GestoresCondominio_GestorCondominioId",
                        column: x => x.GestorCondominioId,
                        principalTable: "GestoresCondominio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post_Utilizadores_UtilizadorId",
                        column: x => x.UtilizadorId,
                        principalTable: "Utilizadores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reunioes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UtilizadorId = table.Column<int>(type: "int", nullable: false),
                    GestorCondominioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reunioes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reunioes_GestoresCondominio_GestorCondominioId",
                        column: x => x.GestorCondominioId,
                        principalTable: "GestoresCondominio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reunioes_Utilizadores_UtilizadorId",
                        column: x => x.UtilizadorId,
                        principalTable: "Utilizadores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtilizadorId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentario_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentario_Utilizadores_UtilizadorId",
                        column: x => x.UtilizadorId,
                        principalTable: "Utilizadores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizadorId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Like_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Like_Utilizadores_UtilizadorId",
                        column: x => x.UtilizadorId,
                        principalTable: "Utilizadores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Participante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Confirma = table.Column<bool>(type: "bit", nullable: false),
                    UtilizadorId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participante_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participante_Utilizadores_UtilizadorId",
                        column: x => x.UtilizadorId,
                        principalTable: "Utilizadores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notificacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vista = table.Column<bool>(type: "bit", nullable: false),
                    UtilizadorId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    ReuniaoId = table.Column<int>(type: "int", nullable: false),
                    IncidenciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificacao_Incidencias_IncidenciaId",
                        column: x => x.IncidenciaId,
                        principalTable: "Incidencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notificacao_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notificacao_Reunioes_ReuniaoId",
                        column: x => x.ReuniaoId,
                        principalTable: "Reunioes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notificacao_Utilizadores_UtilizadorId",
                        column: x => x.UtilizadorId,
                        principalTable: "Utilizadores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_PostId",
                table: "Comentario",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_UtilizadorId",
                table: "Comentario",
                column: "UtilizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Condominios_CP",
                table: "Condominios",
                column: "CP");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_UtilizadorId",
                table: "Contactos",
                column: "UtilizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactosEmergencia_CondominioId",
                table: "ContactosEmergencia",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_GestoresCondominio_CondominioId",
                table: "GestoresCondominio",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_CondominioId",
                table: "Incidencias",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_GestorCondominioId",
                table: "Incidencias",
                column: "GestorCondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_UtilizadorId",
                table: "Incidencias",
                column: "UtilizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_PostId",
                table: "Like",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_UtilizadorId",
                table: "Like",
                column: "UtilizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacao_IncidenciaId",
                table: "Notificacao",
                column: "IncidenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacao_PostId",
                table: "Notificacao",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacao_ReuniaoId",
                table: "Notificacao",
                column: "ReuniaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacao_UtilizadorId",
                table: "Notificacao",
                column: "UtilizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Participante_PostId",
                table: "Participante",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Participante_UtilizadorId",
                table: "Participante",
                column: "UtilizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_GestorCondominioId",
                table: "Post",
                column: "GestorCondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UtilizadorId",
                table: "Post",
                column: "UtilizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reunioes_GestorCondominioId",
                table: "Reunioes",
                column: "GestorCondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reunioes_UtilizadorId",
                table: "Reunioes",
                column: "UtilizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilizadores_CondominioId",
                table: "Utilizadores",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilizadores_GestorCondominioId",
                table: "Utilizadores",
                column: "GestorCondominioId",
                unique: true,
                filter: "[GestorCondominioId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Utilizadores_LoginId",
                table: "Utilizadores",
                column: "LoginId",
                unique: true,
                filter: "[LoginId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropTable(
                name: "ContactosEmergencia");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "Notificacao");

            migrationBuilder.DropTable(
                name: "Participante");

            migrationBuilder.DropTable(
                name: "Incidencias");

            migrationBuilder.DropTable(
                name: "Reunioes");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Utilizadores");

            migrationBuilder.DropTable(
                name: "GestoresCondominio");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Condominios");

            migrationBuilder.DropTable(
                name: "CodigoPostal");
        }
    }
}
