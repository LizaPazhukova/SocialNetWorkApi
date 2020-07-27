using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Dal.Migrations
{
    public partial class AddIsReadedFieldToMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isReaded",
                table: "Messages",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isReaded",
                table: "Messages");
        }
    }
}
