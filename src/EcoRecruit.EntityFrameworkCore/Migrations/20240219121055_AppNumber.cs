using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoRecruit.Migrations
{
    /// <inheritdoc />
    public partial class AppNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ApplicationsData_ApplicantId",
                table: "ApplicationsData");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationsData_JobId_ApplicantId",
                table: "ApplicationsData");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Jobs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantNumber",
                table: "ApplicationsData",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationsData_ApplicantId_ApplicantNumber",
                table: "ApplicationsData",
                columns: new[] { "ApplicantId", "ApplicantNumber" },
                unique: true,
                filter: "[ApplicantNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationsData_JobId",
                table: "ApplicationsData",
                column: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ApplicationsData_ApplicantId_ApplicantNumber",
                table: "ApplicationsData");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationsData_JobId",
                table: "ApplicationsData");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Jobs");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantNumber",
                table: "ApplicationsData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationsData_ApplicantId",
                table: "ApplicationsData",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationsData_JobId_ApplicantId",
                table: "ApplicationsData",
                columns: new[] { "JobId", "ApplicantId" },
                unique: true);
        }
    }
}
