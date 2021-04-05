using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationsAPI.Migrations
{
    public partial class spContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"CREATE PROCEDURE [dbo].[sp_GetContactDetails]
                        AS
						SELECT Id, ContactName, BirthDate, PhoneNumber,
                        (SELECT Id, Description, CASE WHEN  CT.Id = C.ContactTypeId THEN 1 ELSE 0 END [Selected] FROM ContactTypes CT ORDER BY 3 DESC FOR JSON PATH) [Types]
                        FROM Contacts C WHERE C.Id = @id
                        END";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
