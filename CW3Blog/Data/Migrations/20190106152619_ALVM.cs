using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CW3Blog.Data.Migrations
{
    public partial class ALVM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnalyticsViewModel_AnalyticsListViewModel_AnalyticsListViewModelID",
                table: "AnalyticsViewModel");

            migrationBuilder.DropTable(
                name: "AnalyticsListViewModel");

            migrationBuilder.DropIndex(
                name: "IX_AnalyticsViewModel_AnalyticsListViewModelID",
                table: "AnalyticsViewModel");

            migrationBuilder.DropColumn(
                name: "AnalyticsListViewModelID",
                table: "AnalyticsViewModel");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                table: "CommentModel",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "AnalyticsLocationViewModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(nullable: true),
                    NumUsers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalyticsLocationViewModel", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalyticsLocationViewModel");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                table: "CommentModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnalyticsListViewModelID",
                table: "AnalyticsViewModel",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AnalyticsListViewModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalyticsListViewModel", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnalyticsViewModel_AnalyticsListViewModelID",
                table: "AnalyticsViewModel",
                column: "AnalyticsListViewModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_AnalyticsViewModel_AnalyticsListViewModel_AnalyticsListViewModelID",
                table: "AnalyticsViewModel",
                column: "AnalyticsListViewModelID",
                principalTable: "AnalyticsListViewModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
