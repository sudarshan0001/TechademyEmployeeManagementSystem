using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechademyEmployeeManagementSystem.Migrations
{
    public partial class Employee_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(nullable: false),
                    EmployeeEmail = table.Column<string>(nullable: false),
                    EmployeeGender = table.Column<string>(nullable: false),
                    EmployeeDOB = table.Column<DateTime>(nullable: false),
                    EmployeeContact = table.Column<string>(nullable: false),
                    EmployeeAddress = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    EmployeeDesignation = table.Column<string>(nullable: false),
                    EmployeeImage = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.EmployeeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee");
        }
    }
}
