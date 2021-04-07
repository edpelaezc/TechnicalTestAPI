using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationsAPI.Migrations
{
    public partial class DeleteReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"CREATE PROCEDURE [dbo].[sp_DeleteReservation] @id int
                        AS
                        BEGIN 
                        DELETE FROM Reservations WHERE Id = @id
                        END";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
