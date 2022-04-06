using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiSMRv4.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tipoPregunta",
                table: "Elementos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipoPregunta",
                table: "Elementos");
        }
    }
}
