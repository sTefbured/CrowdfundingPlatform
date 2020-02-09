using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdfundingPlatform.Migrations
{
    public partial class ExtendIdentityMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Identifier",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "AspNetUsers");
        }
    }
}
