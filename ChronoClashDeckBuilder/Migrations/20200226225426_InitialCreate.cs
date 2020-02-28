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
                    CardNumber = table.Column<string>(nullable: false),
                    CardSet = table.Column<string>(nullable: true),
                    CardType = table.Column<string>(nullable: true),
                    CardImage = table.Column<string>(nullable: true),
                    CardColor = table.Column<string>(nullable: true),
                    CardCost = table.Column<int>(nullable: false),
                    CardStrength = table.Column<int>(nullable: false),
                    CardName = table.Column<string>(nullable: true),
                    CardAbilities = table.Column<string>(nullable: true),
                    CardStackAbilities = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
