using Microsoft.EntityFrameworkCore.Migrations;

namespace CW3Blog.Data.Migrations
{
    public partial class PostID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostIDID",
                table: "CommentModel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentModel_PostIDID",
                table: "CommentModel",
                column: "PostIDID");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_BlogPostModel_PostIDID",
                table: "CommentModel",
                column: "PostIDID",
                principalTable: "BlogPostModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_BlogPostModel_PostIDID",
                table: "CommentModel");

            migrationBuilder.DropIndex(
                name: "IX_CommentModel_PostIDID",
                table: "CommentModel");

            migrationBuilder.DropColumn(
                name: "PostIDID",
                table: "CommentModel");
        }
    }
}
