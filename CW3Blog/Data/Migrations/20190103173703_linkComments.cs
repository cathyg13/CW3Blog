using Microsoft.EntityFrameworkCore.Migrations;

namespace CW3Blog.Data.Migrations
{
    public partial class linkComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_BlogPostModel_PostIDID",
                table: "CommentModel");

            migrationBuilder.RenameColumn(
                name: "PostIDID",
                table: "CommentModel",
                newName: "BlogPostID");

            migrationBuilder.RenameIndex(
                name: "IX_CommentModel_PostIDID",
                table: "CommentModel",
                newName: "IX_CommentModel_BlogPostID");

            migrationBuilder.AddColumn<int>(
                name: "PostID",
                table: "CommentModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_BlogPostModel_BlogPostID",
                table: "CommentModel",
                column: "BlogPostID",
                principalTable: "BlogPostModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_BlogPostModel_BlogPostID",
                table: "CommentModel");

            migrationBuilder.DropColumn(
                name: "PostID",
                table: "CommentModel");

            migrationBuilder.RenameColumn(
                name: "BlogPostID",
                table: "CommentModel",
                newName: "PostIDID");

            migrationBuilder.RenameIndex(
                name: "IX_CommentModel_BlogPostID",
                table: "CommentModel",
                newName: "IX_CommentModel_PostIDID");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_BlogPostModel_PostIDID",
                table: "CommentModel",
                column: "PostIDID",
                principalTable: "BlogPostModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
