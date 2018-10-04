using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "event_item_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "event_occasion_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "EventCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Category = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventLocation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Location = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventOcassion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Occasion = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventOcassion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PictureUrl = table.Column<string>(nullable: true),
                    EventLocationId = table.Column<int>(nullable: false),
                    EventOccasionId = table.Column<int>(nullable: false),
                    EventCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventItem_EventCategory_EventCategoryId",
                        column: x => x.EventCategoryId,
                        principalTable: "EventCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventItem_EventLocation_EventLocationId",
                        column: x => x.EventLocationId,
                        principalTable: "EventLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventItem_EventOcassion_EventOccasionId",
                        column: x => x.EventOccasionId,
                        principalTable: "EventOcassion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventItem_EventCategoryId",
                table: "EventItem",
                column: "EventCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EventItem_EventLocationId",
                table: "EventItem",
                column: "EventLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_EventItem_EventOccasionId",
                table: "EventItem",
                column: "EventOccasionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventItem");

            migrationBuilder.DropTable(
                name: "EventCategory");

            migrationBuilder.DropTable(
                name: "EventLocation");

            migrationBuilder.DropTable(
                name: "EventOcassion");

            migrationBuilder.DropSequence(
                name: "event_item_hilo");

            migrationBuilder.DropSequence(
                name: "event_occasion_hilo");
        }
    }
}
