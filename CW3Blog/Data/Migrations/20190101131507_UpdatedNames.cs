using Microsoft.EntityFrameworkCore.Migrations;

namespace CW3Blog.Data.Migrations
{
    public partial class UpdatedNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "CommentModel",
                newName: "AuthorName");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "CommentModel",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string));

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

            migrationBuilder.RenameColumn(
                name: "AuthorName",
                table: "CommentModel",
                newName: "Username");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "CommentModel",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2000);
        }
    }
}
