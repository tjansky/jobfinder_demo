using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobFinder.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmploymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HomePageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRemote = table.Column<bool>(type: "bit", nullable: false),
                    EquityAvaliable = table.Column<bool>(type: "bit", nullable: false),
                    ApplyUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    MinSalary = table.Column<int>(type: "int", nullable: false),
                    MaxSalary = table.Column<int>(type: "int", nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentTypeJob",
                columns: table => new
                {
                    EmploymentTypesId = table.Column<int>(type: "int", nullable: false),
                    JobsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentTypeJob", x => new { x.EmploymentTypesId, x.JobsId });
                    table.ForeignKey(
                        name: "FK_EmploymentTypeJob_EmploymentTypes_EmploymentTypesId",
                        column: x => x.EmploymentTypesId,
                        principalTable: "EmploymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmploymentTypeJob_Jobs_JobsId",
                        column: x => x.JobsId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceLevelJob",
                columns: table => new
                {
                    ExperienceLevelsId = table.Column<int>(type: "int", nullable: false),
                    JobsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceLevelJob", x => new { x.ExperienceLevelsId, x.JobsId });
                    table.ForeignKey(
                        name: "FK_ExperienceLevelJob_ExperienceLevels_ExperienceLevelsId",
                        column: x => x.ExperienceLevelsId,
                        principalTable: "ExperienceLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperienceLevelJob_Jobs_JobsId",
                        column: x => x.JobsId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobTechnology",
                columns: table => new
                {
                    JobsId = table.Column<int>(type: "int", nullable: false),
                    TechnologiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTechnology", x => new { x.JobsId, x.TechnologiesId });
                    table.ForeignKey(
                        name: "FK_JobTechnology_Jobs_JobsId",
                        column: x => x.JobsId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobTechnology_Technologies_TechnologiesId",
                        column: x => x.TechnologiesId,
                        principalTable: "Technologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobUser",
                columns: table => new
                {
                    SavedJobsId = table.Column<int>(type: "int", nullable: false),
                    SavedUsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobUser", x => new { x.SavedJobsId, x.SavedUsersId });
                    table.ForeignKey(
                        name: "FK_JobUser_Jobs_SavedJobsId",
                        column: x => x.SavedJobsId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobUser_Users_SavedUsersId",
                        column: x => x.SavedUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReqResBons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReqResBons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReqResBons_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentTypeJob_JobsId",
                table: "EmploymentTypeJob",
                column: "JobsId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceLevelJob_JobsId",
                table: "ExperienceLevelJob",
                column: "JobsId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_OrganizationId",
                table: "Jobs",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTechnology_TechnologiesId",
                table: "JobTechnology",
                column: "TechnologiesId");

            migrationBuilder.CreateIndex(
                name: "IX_JobUser_SavedUsersId",
                table: "JobUser",
                column: "SavedUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ReqResBons_JobId",
                table: "ReqResBons",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmploymentTypeJob");

            migrationBuilder.DropTable(
                name: "ExperienceLevelJob");

            migrationBuilder.DropTable(
                name: "JobTechnology");

            migrationBuilder.DropTable(
                name: "JobUser");

            migrationBuilder.DropTable(
                name: "ReqResBons");

            migrationBuilder.DropTable(
                name: "EmploymentTypes");

            migrationBuilder.DropTable(
                name: "ExperienceLevels");

            migrationBuilder.DropTable(
                name: "Technologies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
