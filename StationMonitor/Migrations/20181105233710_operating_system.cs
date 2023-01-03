using Microsoft.EntityFrameworkCore.Migrations;

namespace StationMonitor.Migrations
{
    public partial class operating_system : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "memory",
                table: "stations",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<string>(
                name: "install_date",
                table: "stations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "last_boot_up_time",
                table: "stations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "local_date_time",
                table: "stations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "os",
                table: "stations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "osarchitecture",
                table: "stations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "osdirectory",
                table: "stations",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "cpuload",
                table: "events",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "free_memory",
                table: "events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "install_date",
                table: "stations");

            migrationBuilder.DropColumn(
                name: "last_boot_up_time",
                table: "stations");

            migrationBuilder.DropColumn(
                name: "local_date_time",
                table: "stations");

            migrationBuilder.DropColumn(
                name: "os",
                table: "stations");

            migrationBuilder.DropColumn(
                name: "osarchitecture",
                table: "stations");

            migrationBuilder.DropColumn(
                name: "osdirectory",
                table: "stations");

            migrationBuilder.DropColumn(
                name: "cpuload",
                table: "events");

            migrationBuilder.DropColumn(
                name: "free_memory",
                table: "events");

            migrationBuilder.AlterColumn<double>(
                name: "memory",
                table: "stations",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
