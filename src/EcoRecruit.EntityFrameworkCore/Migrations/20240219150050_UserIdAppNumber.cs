using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoRecruit.Migrations
{
    /// <inheritdoc />
    public partial class UserIdAppNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Jobs_JobId",
                table: "Applicants");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationsData_Applicants_ApplicantId",
                table: "ApplicationsData");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationsData_Jobs_JobId",
                table: "ApplicationsData");

            migrationBuilder.DropIndex(
                name: "IX_Applicants_JobId",
                table: "Applicants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationsData",
                table: "ApplicationsData");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationsData_ApplicantId_ApplicantNumber",
                table: "ApplicationsData");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Applicants");

            migrationBuilder.RenameTable(
                name: "ApplicationsData",
                newName: "Applications");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationsData_JobId",
                table: "Applications",
                newName: "IX_Applications_JobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicantId",
                table: "Applications",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId_ApplicantNumber",
                table: "Applications",
                columns: new[] { "UserId", "ApplicantNumber" },
                unique: true,
                filter: "[ApplicantNumber] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Applicants_ApplicantId",
                table: "Applications",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Jobs_JobId",
                table: "Applications",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Applicants_ApplicantId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Jobs_JobId",
                table: "Applications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ApplicantId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_UserId_ApplicantNumber",
                table: "Applications");

            migrationBuilder.RenameTable(
                name: "Applications",
                newName: "ApplicationsData");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_JobId",
                table: "ApplicationsData",
                newName: "IX_ApplicationsData_JobId");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Applicants",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationsData",
                table: "ApplicationsData",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_JobId",
                table: "Applicants",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationsData_ApplicantId_ApplicantNumber",
                table: "ApplicationsData",
                columns: new[] { "ApplicantId", "ApplicantNumber" },
                unique: true,
                filter: "[ApplicantNumber] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Jobs_JobId",
                table: "Applicants",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationsData_Applicants_ApplicantId",
                table: "ApplicationsData",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationsData_Jobs_JobId",
                table: "ApplicationsData",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
