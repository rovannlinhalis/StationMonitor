using Microsoft.EntityFrameworkCore.Migrations;

namespace StationMonitor.Migrations
{
    public partial class operating_system2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "memory",
                table: "stations",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<decimal>(
                name: "free_memory",
                table: "events",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "memory",
                table: "stations",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<long>(
                name: "free_memory",
                table: "events",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
