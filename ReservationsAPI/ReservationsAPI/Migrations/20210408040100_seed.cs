using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationsAPI.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Contact Type 1" });

            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "Contact Type 2" });

            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { 3, "Contact Type 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
