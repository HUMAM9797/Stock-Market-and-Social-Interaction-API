using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace asp.net_youtube_course.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Purches = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastDiv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketCap = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MyProperty = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Stock_StockId",
                        column: x => x.StockId,
                        principalTable: "Stock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "Id", "CompanyName", "Industry", "IsDeleted", "LastDiv", "MarketCap", "Purches", "Symbol" },
                values: new object[,]
                {
                    { 1, "APPLE INC", "Technology", false, 2.5m, 3000000000L, 250.00m, "AAPL" },
                    { 2, "MICROSOFT", "Technology", false, 3.0m, 2500000000L, 150.00m, "MSFT" },
                    { 3, "Tesla Inc", "Automotive", false, 0.0m, 600000000000L, 180.00m, "TSLA" },
                    { 4, "Amazon.com", "Technology", false, 0.0m, 1500000000000L, 140.00m, "AMZN" },
                    { 5, "NVIDIA Corp", "Technology", false, 0.16m, 2000000000000L, 800.00m, "NVDA" },
                    { 6, "Alphabet Inc", "Technology", false, 0.0m, 1700000000000L, 140.00m, "GOOGL" },
                    { 7, "Meta Platforms", "Technology", false, 0.50m, 1200000000000L, 480.00m, "META" },
                    { 8, "Berkshire Hathaway", "Financial Services", false, 0.0m, 900000000000L, 400.00m, "BRK.B" },
                    { 9, "Eli Lilly", "Healthcare", false, 1.30m, 700000000000L, 750.00m, "LLY" },
                    { 10, "Broadcom Inc", "Technology", false, 5.25m, 600000000000L, 1200.00m, "AVGO" },
                    { 11, "JPMorgan Chase", "Financial Services", false, 1.05m, 500000000000L, 180.00m, "JPM" },
                    { 12, "Visa Inc", "Financial Services", false, 0.52m, 550000000000L, 280.00m, "V" },
                    { 13, "Walmart Inc", "Consumer Defensive", false, 0.20m, 450000000000L, 60.00m, "WMT" },
                    { 14, "Exxon Mobil", "Energy", false, 0.95m, 400000000000L, 105.00m, "XOM" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "IsDeleted", "MyProperty", "StockId", "Title" },
                values: new object[,]
                {
                    { 1, "Long term hold", false, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Great company" },
                    { 2, "Dividends are okay, could be better", false, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dividends" },
                    { 3, "Azure is growing fast", false, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Cloud King" },
                    { 4, "High risk high reward", false, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Volatile" },
                    { 5, "AWS is the money maker", false, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "AWS" },
                    { 6, "NVIDIA is leading the AI revolution", false, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "AI Boom" },
                    { 7, "Google still dominates search", false, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Search Monopoly" },
                    { 8, "Betting big on the future", false, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Metaverse" },
                    { 9, "Safe haven asset", false, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Warren Buffett" },
                    { 10, "New drugs are game changers", false, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Weight Loss" },
                    { 11, "Strong demand for chips", false, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Semiconductors" },
                    { 12, "Best managed bank", false, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "Bank Leader" },
                    { 13, "Cashless society beneficiary", false, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Payments" },
                    { 14, "Low prices everyday", false, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, "Retail Giant" },
                    { 15, "Energy demand remains high", false, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, "Oil & Gas" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_StockId",
                table: "Comments",
                column: "StockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Stock");
        }
    }
}
