using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookings.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    TravelAgentId = table.Column<int>(type: "int", nullable: true),
                    AvailableCount = table.Column<int>(type: "int", nullable: true),
                    TravellerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravellerCount = table.Column<int>(type: "int", nullable: false),
                    PickUp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Drop = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalTravellers",
                columns: table => new
                {
                    AdditionalTravellerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageId = table.Column<int>(type: "int", nullable: true),
                    id = table.Column<int>(type: "int", nullable: true),
                    TravellerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalTravellers", x => x.AdditionalTravellerId);
                    table.ForeignKey(
                        name: "FK_AdditionalTravellers_Bookings_id",
                        column: x => x.id,
                        principalTable: "Bookings",
                        principalColumn: "BookingId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalTravellers_id",
                table: "AdditionalTravellers",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalTravellers");

            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
