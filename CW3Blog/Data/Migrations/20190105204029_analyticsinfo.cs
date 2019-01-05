using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CW3Blog.Data.Migrations
{
    public partial class analyticsinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Avatar",
                table: "User",
                newName: "Location");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "User",
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

            migrationBuilder.CreateTable(
                name: "AnalyticsViewModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnalyticsListViewModelID = table.Column<int>(nullable: true),
                    AuthorName = table.Column<string>(nullable: true),
                    NumComments = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalyticsViewModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AnalyticsViewModel_AnalyticsListViewModel_AnalyticsListViewModelID",
                        column: x => x.AnalyticsListViewModelID,
                        principalTable: "AnalyticsListViewModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnalyticsViewModel_AnalyticsListViewModelID",
                table: "AnalyticsViewModel",
                column: "AnalyticsListViewModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalyticsViewModel");

            migrationBuilder.DropTable(
                name: "AnalyticsListViewModel");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "User",
                newName: "Avatar");
        }
    }
}
