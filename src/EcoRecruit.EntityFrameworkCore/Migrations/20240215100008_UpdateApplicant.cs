using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoRecruit.Migrations
{
    /// <inheritdoc />
    public partial class UpdateApplicant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Middle",
                table: "Applicants",
                newName: "MiddleName");

            migrationBuilder.AddColumn<string>(
                name: "Headline",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearsOfExperience",
                table: "Applicants",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Headline",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "YearsOfExperience",
                table: "Applicants");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "Applicants",
                newName: "Middle");
        }
    }
}
