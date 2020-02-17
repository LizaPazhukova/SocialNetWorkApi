using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Dal.Migrations
{
    public partial class ConfigureRelationBetweenUserAndFriendRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Requests_FromUserId",
                table: "Requests",
                column: "FromUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_FromUserId",
                table: "Requests",
                column: "FromUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_FromUserId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_FromUserId",
                table: "Requests");
        }
    }
}
