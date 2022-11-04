using Microsoft.EntityFrameworkCore.Migrations;

namespace TechademyEmployeeManagementSystem.Migrations
{
    public partial class Employee_Added_updated_contact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmployeeContact",
                table: "employee",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EmployeeContact",
                table: "employee",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
