using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShop.Migrations
{
    public partial class update6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "SchemaEnd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserProfileId = table.Column<int>(type: "int", nullable: false),
                    ResponseOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalSchema: "SchemaEnd",
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "SchemaEnd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Book_BookId",
                        column: x => x.BookId,
                        principalSchema: "SchemaEnd",
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalSchema: "SchemaEnd",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_BookId",
                schema: "SchemaEnd",
                table: "Order",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrdersId",
                schema: "SchemaEnd",
                table: "Order",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserProfileId",
                schema: "SchemaEnd",
                table: "Orders",
                column: "UserProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order",
                schema: "SchemaEnd");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "SchemaEnd");
        }
    }
}
