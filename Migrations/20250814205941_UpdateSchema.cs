using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProducts.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rols",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
