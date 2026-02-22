using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace asp.net_youtube_course.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "Id", "CompanyName", "Industry", "IsDeleted", "LastDiv", "MarketCap", "Purches", "Symbol" },
                values: new object[,]
                {
                    { 1, "APPLE INC", "Technology", false, 2.5m, 3000000000L, 250.00m, "AAPL" },
                    { 2, "MICROSOFT", "Technology", false, 3.0m, 2500000000L, 150.00m, "MSFT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stock",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stock",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
