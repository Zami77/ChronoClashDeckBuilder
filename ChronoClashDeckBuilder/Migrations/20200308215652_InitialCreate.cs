using Microsoft.EntityFrameworkCore.Migrations;

namespace ChronoClashDeckBuilder.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardNumber = table.Column<string>(maxLength: 20, nullable: false),
                    CardSet = table.Column<string>(maxLength: 20, nullable: true),
                    CardType = table.Column<string>(maxLength: 20, nullable: true),
                    CardImage = table.Column<string>(maxLength: 100, nullable: true),
                    CardColor = table.Column<string>(maxLength: 10, nullable: true),
                    CardCost = table.Column<int>(nullable: true),
                    CardStrength = table.Column<int>(nullable: true),
                    CardName = table.Column<string>(maxLength: 80, nullable: true),
                    CardAbilities = table.Column<string>(maxLength: 200, nullable: true),
                    CardStackAbilities = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CardData__A4E9FFE8515C0491", x => x.CardNumber);
                });

            migrationBuilder.CreateTable(
                name: "Decks",
                columns: table => new
                {
                    DeckID = table.Column<int>(nullable: false),
                    NumberOfMainDeck = table.Column<int>(nullable: true),
                    NumberOfSideDeck = table.Column<int>(nullable: true),
                    NumberOfExtraDeck = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DeckData__76B5444CE62B9516", x => x.DeckID);
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    Username = table.Column<string>(maxLength: 80, nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: true),
                    Password = table.Column<string>(maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserAcco__536C85E556D88902", x => x.Username);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Decks");

            migrationBuilder.DropTable(
                name: "UserAccount");
        }
    }
}
