using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoRecruit.Migrations
{
    /// <inheritdoc />
    public partial class UpdateApplicantAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Availability",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability",
                table: "Applicants");
        }
    }
}
