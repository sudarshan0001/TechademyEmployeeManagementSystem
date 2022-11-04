using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechademyEmployeeManagementSystem.Migrations
{
    public partial class Leave_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leave",
                columns: table => new
                {
                    LeaveId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveType = table.Column<string>(nullable: false),
                    LeaveDays = table.Column<string>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    LeaveReason = table.Column<string>(nullable: false),
                    LeaveStatus = table.Column<string>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leave", x => x.LeaveId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leave");
        }
    }
}
