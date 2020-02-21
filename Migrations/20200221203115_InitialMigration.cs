using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdfundingPlatform.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39724639-b3e8-4069-b24d-60a384f003f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4798321-9ef9-4383-a217-af8699154fee");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "993952a6-fd52-464a-ab42-4c16098a9e31", "741acf1c-9660-49be-88d8-052694dc180d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "85ebde07-26db-46ff-a78f-8b2b20bd62bb", "b6f2888a-fa8f-4836-8f9f-cd8b79ee68e8", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85ebde07-26db-46ff-a78f-8b2b20bd62bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993952a6-fd52-464a-ab42-4c16098a9e31");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a4798321-9ef9-4383-a217-af8699154fee", "fe49632e-cb6d-46b8-96b0-9dd21be53e8c", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "39724639-b3e8-4069-b24d-60a384f003f8", "0a417b30-3c37-41b5-9f26-070220d579cd", "User", "USER" });
        }
    }
}
