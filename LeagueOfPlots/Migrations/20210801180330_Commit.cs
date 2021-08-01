using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeagueOfPlots.Migrations
{
    public partial class Commit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BIRTHDATE",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FACEBOOK",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FAUX_FREROT_POINTS",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "INSTAGRAM",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TWITTER",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BIRTHDATE",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FACEBOOK",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FAUX_FREROT_POINTS",
                table: "User");

            migrationBuilder.DropColumn(
                name: "INSTAGRAM",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TWITTER",
                table: "User");
        }
    }
}
