using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationsAPI.Migrations
{
    public partial class UpdateReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"CREATE PROCEDURE [dbo].[sp_UpdateReservation] @id int, @contact int, @description nvarchar(MAX)
                        AS
                        BEGIN 
                        UPDATE Reservations SET Description = @description WHERE Id = @id and ContactId = @contact
                        END";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
