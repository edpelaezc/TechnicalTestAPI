using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationsAPI.Migrations
{
    public partial class spGetReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"CREATE PROCEDURE [dbo].[sp_GetReservation] @id int
                        AS
                        BEGIN 
                        select R.Id, R.Description, C.Id as ContactId, C.ContactName, C.ContactTypeId, CT.Description as ContactType, C.PhoneNumber, C.BirthDate from Reservations R INNER JOIN Contacts C ON R.ContactId = C.Id  INNER JOIN ContactTypes CT ON CT.Id = C.ContactTypeId where R.Id = @id
                        END";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
