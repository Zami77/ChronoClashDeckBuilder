using Microsoft.EntityFrameworkCore.Migrations;

namespace ChronoClashDeckBuilder.Migrations
{
    public partial class DeckCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cards",
                table: "Decks");

            migrationBuilder.AddColumn<string>(
                name: "ExtraDeckCards",
                table: "Decks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainDeckCards",
                table: "Decks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraDeckCards",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "MainDeckCards",
                table: "Decks");

            migrationBuilder.AddColumn<string>(
                name: "Cards",
                table: "Decks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
