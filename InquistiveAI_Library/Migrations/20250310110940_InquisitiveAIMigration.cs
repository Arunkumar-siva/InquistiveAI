using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InquistiveAI_Library.Migrations
{
    /// <inheritdoc />
    public partial class InquisitiveAIMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AssesmentDetails",
                newName: "AssessmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssessmentId",
                table: "AssesmentDetails",
                newName: "Id");
        }
    }
}
