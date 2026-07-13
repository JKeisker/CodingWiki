using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedAuthorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Author_Id", "BirthDate", "FirstName", "LastName", "Location" },
                values: new object[,]
                {
                    { 1, new DateTime(1965, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill", "Shakespeare", "Chicago" },
                    { 2, new DateTime(1975, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Larry", "Bird", "Chicago" },
                    { 3, new DateTime(1987, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom", "Barrett", "Chicago" },
                    { 4, new DateTime(1945, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Betty", "Thomas", "Chicago" },
                    { 5, new DateTime(1955, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shanna", "Leon", "Chicago" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Author_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Author_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Author_Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Author_Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Author_Id",
                keyValue: 5);
        }
    }
}
