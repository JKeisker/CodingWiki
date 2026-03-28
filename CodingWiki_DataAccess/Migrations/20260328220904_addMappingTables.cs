using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addMappingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Authors_Author_Id",
                table: "BookAuthorMap");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Books_Book_Id",
                table: "BookAuthorMap");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookAuthorMap_Fluent_Authors_Author_Id",
                table: "Fluent_BookAuthorMap");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookAuthorMap_Fluent_Books_Book_Id",
                table: "Fluent_BookAuthorMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_BookAuthorMap",
                table: "Fluent_BookAuthorMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthorMap",
                table: "BookAuthorMap");

            migrationBuilder.RenameTable(
                name: "Fluent_BookAuthorMap",
                newName: "Fluent_bookAuthorMaps");

            migrationBuilder.RenameTable(
                name: "BookAuthorMap",
                newName: "bookAuthorMaps");

            migrationBuilder.RenameIndex(
                name: "IX_Fluent_BookAuthorMap_Book_Id",
                table: "Fluent_bookAuthorMaps",
                newName: "IX_Fluent_bookAuthorMaps_Book_Id");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthorMap_Book_Id",
                table: "bookAuthorMaps",
                newName: "IX_bookAuthorMaps_Book_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_bookAuthorMaps",
                table: "Fluent_bookAuthorMaps",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookAuthorMaps",
                table: "bookAuthorMaps",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_bookAuthorMaps_Authors_Author_Id",
                table: "bookAuthorMaps",
                column: "Author_Id",
                principalTable: "Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bookAuthorMaps_Books_Book_Id",
                table: "bookAuthorMaps",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_bookAuthorMaps_Fluent_Authors_Author_Id",
                table: "Fluent_bookAuthorMaps",
                column: "Author_Id",
                principalTable: "Fluent_Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_bookAuthorMaps_Fluent_Books_Book_Id",
                table: "Fluent_bookAuthorMaps",
                column: "Book_Id",
                principalTable: "Fluent_Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookAuthorMaps_Authors_Author_Id",
                table: "bookAuthorMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_bookAuthorMaps_Books_Book_Id",
                table: "bookAuthorMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_bookAuthorMaps_Fluent_Authors_Author_Id",
                table: "Fluent_bookAuthorMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_bookAuthorMaps_Fluent_Books_Book_Id",
                table: "Fluent_bookAuthorMaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_bookAuthorMaps",
                table: "Fluent_bookAuthorMaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookAuthorMaps",
                table: "bookAuthorMaps");

            migrationBuilder.RenameTable(
                name: "Fluent_bookAuthorMaps",
                newName: "Fluent_BookAuthorMap");

            migrationBuilder.RenameTable(
                name: "bookAuthorMaps",
                newName: "BookAuthorMap");

            migrationBuilder.RenameIndex(
                name: "IX_Fluent_bookAuthorMaps_Book_Id",
                table: "Fluent_BookAuthorMap",
                newName: "IX_Fluent_BookAuthorMap_Book_Id");

            migrationBuilder.RenameIndex(
                name: "IX_bookAuthorMaps_Book_Id",
                table: "BookAuthorMap",
                newName: "IX_BookAuthorMap_Book_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_BookAuthorMap",
                table: "Fluent_BookAuthorMap",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthorMap",
                table: "BookAuthorMap",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Authors_Author_Id",
                table: "BookAuthorMap",
                column: "Author_Id",
                principalTable: "Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Books_Book_Id",
                table: "BookAuthorMap",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookAuthorMap_Fluent_Authors_Author_Id",
                table: "Fluent_BookAuthorMap",
                column: "Author_Id",
                principalTable: "Fluent_Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookAuthorMap_Fluent_Books_Book_Id",
                table: "Fluent_BookAuthorMap",
                column: "Book_Id",
                principalTable: "Fluent_Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
