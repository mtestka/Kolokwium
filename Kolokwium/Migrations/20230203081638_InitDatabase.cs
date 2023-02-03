using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kolokwium.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    IdTeam = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.IdTeam);
                });

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    IdTaskType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.IdTaskType);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    IdTeamMember = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.IdTeamMember);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    IdTask = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTeam = table.Column<int>(type: "int", nullable: false),
                    IdTaskType = table.Column<int>(type: "int", nullable: false),
                    IdAssignedTo = table.Column<int>(type: "int", nullable: false),
                    IdCreator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.IdTask);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Projects",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskTypes_IdTaskType",
                        column: x => x.IdTaskType,
                        principalTable: "TaskTypes",
                        principalColumn: "IdTaskType",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_TeamMembers_IdAssignedTo",
                        column: x => x.IdAssignedTo,
                        principalTable: "TeamMembers",
                        principalColumn: "IdTeamMember",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_TeamMembers_IdCreator",
                        column: x => x.IdCreator,
                        principalTable: "TeamMembers",
                        principalColumn: "IdTeamMember",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_IdAssignedTo",
                table: "Tasks",
                column: "IdAssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_IdCreator",
                table: "Tasks",
                column: "IdCreator");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_IdTaskType",
                table: "Tasks",
                column: "IdTaskType");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_IdTeam",
                table: "Tasks",
                column: "IdTeam");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DropTable(
                name: "TeamMembers");
        }
    }
}
