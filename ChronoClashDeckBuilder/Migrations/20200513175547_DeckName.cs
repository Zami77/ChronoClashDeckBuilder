using Microsoft.EntityFrameworkCore.Migrations;

namespace ChronoClashDeckBuilder.Migrations
{
    public partial class DeckName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeckName",
                table: "Decks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeckName",
                table: "Decks");
        }
    }
}
