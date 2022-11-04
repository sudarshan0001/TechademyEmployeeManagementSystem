using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechademyEmployeeManagementSystem.Migrations
{
    public partial class Employee_Added_updated_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "employee");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "employee",
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "employee",
                nullable: false,
                defaultValue: new byte[] {  });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "employee");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
