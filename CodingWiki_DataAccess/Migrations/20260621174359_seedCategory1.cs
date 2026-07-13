using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedCategory1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories VALUES ('Cat 6')");
            migrationBuilder.Sql("INSERT INTO Categories VALUES ('Cat 7')");
            migrationBuilder.Sql("INSERT INTO Categories VALUES ('Cat 8')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
