using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiSMRv4.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Maturity_levels",
                table: "Maturity_levels");

            migrationBuilder.AlterColumn<string>(
                name: "NombreLevel",
                table: "Maturity_levels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Maturity_levels",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ciudad",
                table: "Maturity_levels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maturity_levels",
                table: "Maturity_levels",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Maturity_levels",
                table: "Maturity_levels");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Maturity_levels");

            migrationBuilder.DropColumn(
                name: "ciudad",
                table: "Maturity_levels");

            migrationBuilder.AlterColumn<string>(
                name: "NombreLevel",
                table: "Maturity_levels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maturity_levels",
                table: "Maturity_levels",
                column: "NombreLevel");
        }
    }
}
