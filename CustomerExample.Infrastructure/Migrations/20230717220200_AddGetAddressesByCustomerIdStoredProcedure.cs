using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerExample.Infrastructure.Migrations
{
    public partial class AddGetAddressesByCustomerIdStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE GetAddressesByCustomerId
                    @CustomerId INT
                AS
                BEGIN
                    SELECT *
                    FROM Addresses
                    WHERE CustomerId = @CustomerId;
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetAddressesByCustomerId;");
        }
    }
}
