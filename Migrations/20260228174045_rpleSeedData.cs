using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace asp.net_youtube_course.Migrations
{
    /// <inheritdoc />
    public partial class rpleSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "68e366cc-d4c6-4c2e-b72e-cd496d860892", null, "User", "USER" },
                    { "722a36fb-eeaf-4227-ae40-c13e451c2bb7", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68e366cc-d4c6-4c2e-b72e-cd496d860892");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "722a36fb-eeaf-4227-ae40-c13e451c2bb7");
        }
    }
}
