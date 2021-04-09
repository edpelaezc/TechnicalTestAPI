using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationsAPI.Migrations
{
    public partial class editContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"CREATE PROCEDURE [dbo].[sp_GetContact] @id int
                        AS
                        BEGIN 
                        SELECT Id, ContactName, BirthDate, PhoneNumber,
                        (SELECT Id, Description, CASE WHEN  CT.Id = C.ContactTypeId THEN 1 ELSE 0 END [Selected] FROM ContactTypes CT ORDER BY 3 DESC FOR JSON PATH) [Types]
                        FROM Contacts C WHERE C.Id = @id 
                        END";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactsViewModels");
        }
    }
}
