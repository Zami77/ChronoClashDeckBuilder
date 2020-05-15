using Microsoft.EntityFrameworkCore.Migrations;

namespace ChronoClashDeckBuilder.Migrations
{
    public partial class DecksWithUsernames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Decks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Decks");
        }
    }
}
