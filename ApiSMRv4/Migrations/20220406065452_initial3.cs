using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiSMRv4.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Valor",
                table: "PreguntasTabla",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Valor",
                table: "Elementos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "PreguntasTabla");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Elementos");
        }
    }
}
