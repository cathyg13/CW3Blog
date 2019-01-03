using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CW3Blog.Data.Migrations
{
    public partial class LinkComments2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostID",
                table: "CommentModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostID",
                table: "CommentModel",
                nullable: false,
                defaultValue: 0);
        }
    }
}
