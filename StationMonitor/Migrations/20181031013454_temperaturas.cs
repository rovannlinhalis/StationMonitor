using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StationMonitor.Migrations
{
    public partial class temperaturas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "last_update",
                table: "stations",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "y",
                table: "events",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "x",
                table: "events",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<double>(
                name: "current_temperature",
                table: "events",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "warning_temperature",
                table: "events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "last_update",
                table: "stations");

            migrationBuilder.DropColumn(
                name: "current_temperature",
                table: "events");

            migrationBuilder.DropColumn(
                name: "warning_temperature",
                table: "events");

            migrationBuilder.AlterColumn<int>(
                name: "y",
                table: "events",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "x",
                table: "events",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
