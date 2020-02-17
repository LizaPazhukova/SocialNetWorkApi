using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Dal.Migrations
{
    public partial class Comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentPostId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostId",
                table: "Posts",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Posts_PostId",
                table: "Posts",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Posts_PostId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PostId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ParentPostId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Posts");
        }
    }
}
