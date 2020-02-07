using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdfundingPlatform.Migrations
{
    public partial class SeedModelsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Everything connected with rockets.", "Rocketry" });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "CategoryId", "FullDescription", "GoalDate", "ImageGalleryUrl", "IsPopular", "MoneyEarned", "MoneyGoal", "Name", "RegistrationDate", "ShortDescription", "VideoUrl" },
                values: new object[] { 1, 1, "RoX is a bunch of people with a fantastic idea: bringing humanity to outer planets.", new DateTime(2025, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0.0, 1000000.0, "RoX", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock it, RoX's rockets!", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
