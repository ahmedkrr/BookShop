using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShop.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                schema: "SchemaEnd",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "SchemaEnd",
                table: "Book",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                schema: "SchemaEnd",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PublishDate",
                schema: "SchemaEnd",
                table: "Book",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TotalPages",
                schema: "SchemaEnd",
                table: "Book",
                type: "int",
                maxLength: 70,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Author",
                schema: "SchemaEnd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                schema: "SchemaEnd",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Title",
                schema: "SchemaEnd",
                table: "Book",
                column: "Title",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorId",
                schema: "SchemaEnd",
                table: "Book",
                column: "AuthorId",
                principalSchema: "SchemaEnd",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorId",
                schema: "SchemaEnd",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Author",
                schema: "SchemaEnd");

            migrationBuilder.DropIndex(
                name: "IX_Book_AuthorId",
                schema: "SchemaEnd",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_Title",
                schema: "SchemaEnd",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                schema: "SchemaEnd",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "PublishDate",
                schema: "SchemaEnd",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "TotalPages",
                schema: "SchemaEnd",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "Title",
                schema: "SchemaEnd",
                table: "Book",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                schema: "SchemaEnd",
                table: "Book",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
