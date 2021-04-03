using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationsAPI.Migrations
{
    public partial class spContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"CREATE PROCEDURE [dbo].[sp_GetContactDetails]
                        AS
                        BEGIN 
                        SELECT C.Id, ContactName, BirthDate, Description, PhoneNumber FROM Contacts C INNER JOIN ContactTypes CT ON C.ContactTypeId = CT.Id
                        END";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
