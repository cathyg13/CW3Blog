using Microsoft.EntityFrameworkCore.Migrations;

namespace CW3Blog.Data.Migrations
{
    public partial class ChangeBack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostModel_User_UserID",
                table: "BlogPostModel");

            migrationBuilder.DropIndex(
                name: "IX_BlogPostModel_UserID",
                table: "BlogPostModel");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "BlogPostModel");

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "BlogPostModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "BlogPostModel");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "BlogPostModel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostModel_UserID",
                table: "BlogPostModel",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostModel_User_UserID",
                table: "BlogPostModel",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
