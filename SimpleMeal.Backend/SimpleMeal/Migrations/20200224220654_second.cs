using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleMeal.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvaliable",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TempoPreparo",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "URLImagem",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvaliable",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TempoPreparo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "URLImagem",
                table: "Products");
        }
    }
}
