using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiSMRv4.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfesionalRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    mainChallenges = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Maturity_levels",
                columns: table => new
                {
                    NombreLevel = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Subdimension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxPregunta = table.Column<int>(type: "int", nullable: false),
                    valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maturity_levels", x => x.NombreLevel);
                });

            migrationBuilder.CreateTable(
                name: "Preguntas",
                columns: table => new
                {
                    PreguntaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Pregunta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subdimension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipoPregunta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preguntas", x => x.PreguntaId);
                });

            migrationBuilder.CreateTable(
                name: "Subdimensiones",
                columns: table => new
                {
                    Subdimension = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Dimension = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subdimensiones", x => x.Subdimension);
                });

            migrationBuilder.CreateTable(
                name: "Elementos",
                columns: table => new
                {
                    ElementoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPregunta = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tipoPregunta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Elemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elementos", x => x.ElementoId);
                    table.ForeignKey(
                        name: "FK_Elementos_Preguntas_IdPregunta",
                        column: x => x.IdPregunta,
                        principalTable: "Preguntas",
                        principalColumn: "PreguntaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreguntasTabla",
                columns: table => new
                {
                    PreguntasTablaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPregunta = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ElementoPregunta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreguntasTabla", x => x.PreguntasTablaId);
                    table.ForeignKey(
                        name: "FK_PreguntasTabla_Preguntas_IdPregunta",
                        column: x => x.IdPregunta,
                        principalTable: "Preguntas",
                        principalColumn: "PreguntaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respuestas",
                columns: table => new
                {
                    IdRespuesta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Año = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdPregunta = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Respuesta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuestas", x => x.IdRespuesta);
                    table.ForeignKey(
                        name: "FK_Respuestas_Clientes_Email",
                        column: x => x.Email,
                        principalTable: "Clientes",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Respuestas_Preguntas_IdPregunta",
                        column: x => x.IdPregunta,
                        principalTable: "Preguntas",
                        principalColumn: "PreguntaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elementos_IdPregunta",
                table: "Elementos",
                column: "IdPregunta");

            migrationBuilder.CreateIndex(
                name: "IX_PreguntasTabla_IdPregunta",
                table: "PreguntasTabla",
                column: "IdPregunta");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_Email",
                table: "Respuestas",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_IdPregunta",
                table: "Respuestas",
                column: "IdPregunta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elementos");

            migrationBuilder.DropTable(
                name: "Maturity_levels");

            migrationBuilder.DropTable(
                name: "PreguntasTabla");

            migrationBuilder.DropTable(
                name: "Respuestas");

            migrationBuilder.DropTable(
                name: "Subdimensiones");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Preguntas");
        }
    }
}
