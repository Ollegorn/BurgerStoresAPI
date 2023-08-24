using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    StoreLocation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    StorePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsStoreOpen = table.Column<bool>(type: "bit", nullable: false),
                    BurgerIds = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreId);
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "BurgerIds", "IsStoreOpen", "StoreLocation", "StoreName", "StorePhoneNumber" },
                values: new object[,]
                {
                    { 1, "burgerIds=1&burgerIds=2&burgerIds=3", true, "Athens", "BestBurger", "1234567890" },
                    { 2, "burgerIds=2&burgerIds=3&burgerIds=4", true, "Mexico", "Amigos", "1234567890" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
