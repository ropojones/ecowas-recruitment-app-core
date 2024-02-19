using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoRecruit.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedJobs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Jobs",
                newName: "Supervisor");

            migrationBuilder.AddColumn<int>(
                name: "AgeLimit",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "AnnualSalary",
                table: "Jobs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Directorate",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Division",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DutyStation",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyCompetences",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeLimit",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "AnnualSalary",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Directorate",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Division",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "DutyStation",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "KeyCompetences",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "Supervisor",
                table: "Jobs",
                newName: "Location");
        }
    }
}
