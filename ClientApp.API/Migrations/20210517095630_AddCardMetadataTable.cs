using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientApp.API.Migrations
{
    public partial class AddCardMetadataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetaData",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "MetaDataId",
                table: "Cards",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CardsMetadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Metadata = table.Column<int>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardsMetadata", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardsMetadata");

            migrationBuilder.DropColumn(
                name: "MetaDataId",
                table: "Cards");

            migrationBuilder.AddColumn<string>(
                name: "MetaData",
                table: "Cards",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
