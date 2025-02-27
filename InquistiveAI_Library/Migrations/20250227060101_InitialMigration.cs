using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InquistiveAI_Library.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BatchDetails",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchMonth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchDetails", x => x.BatchId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "AssesmentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    AssessmentUploadedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssesmentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssesmentDetails_BatchDetails_BatchId",
                        column: x => x.BatchId,
                        principalTable: "BatchDetails",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDetails",
                columns: table => new
                {
                    AceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDetails", x => x.AceId);
                    table.ForeignKey(
                        name: "FK_EmployeeDetails_BatchDetails_BatchId",
                        column: x => x.BatchId,
                        principalTable: "BatchDetails",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDetails_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAssesmentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    AssessmentId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AssessmentSubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAssesmentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAssesmentDetails_AssesmentDetails_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "AssesmentDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeAssesmentDetails_BatchDetails_BatchId",
                        column: x => x.BatchId,
                        principalTable: "BatchDetails",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeAssesmentDetails_EmployeeDetails_AceId",
                        column: x => x.AceId,
                        principalTable: "EmployeeDetails",
                        principalColumn: "AceId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Login_EmployeeDetails_AceId",
                        column: x => x.AceId,
                        principalTable: "EmployeeDetails",
                        principalColumn: "AceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssesmentDetails_BatchId",
                table: "AssesmentDetails",
                column: "BatchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAssesmentDetails_AceId",
                table: "EmployeeAssesmentDetails",
                column: "AceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAssesmentDetails_AssessmentId",
                table: "EmployeeAssesmentDetails",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAssesmentDetails_BatchId",
                table: "EmployeeAssesmentDetails",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetails_BatchId",
                table: "EmployeeDetails",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetails_RoleId",
                table: "EmployeeDetails",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Login_AceId",
                table: "Login",
                column: "AceId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAssesmentDetails");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "AssesmentDetails");

            migrationBuilder.DropTable(
                name: "EmployeeDetails");

            migrationBuilder.DropTable(
                name: "BatchDetails");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
