using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vanitha_WebApi_Day_2_HandsOn.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DEPARTMENT",
                columns: table => new
                {
                    DId = table.Column<int>(type: "int", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Department__AF2DBB995C0BD1CF", x => x.DId);
                });

            migrationBuilder.CreateTable(
                name: "EMPL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Salary = table.Column<decimal>(type: "money", nullable: false),
                    Permanent = table.Column<bool>(type: "bit", nullable: false),
                    DepartmentDId = table.Column<int>(type: "int", nullable: true),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__AF2DBB995C0BD1CF", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EMPL_DEPARTMENT_DepartmentDId",
                        column: x => x.DepartmentDId,
                        principalTable: "DEPARTMENT",
                        principalColumn: "DId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "DNAME_IDX",
                table: "DEPARTMENT",
                column: "DepartmentName");

            migrationBuilder.CreateIndex(
                name: "ENAME_IDX",
                table: "EMPL",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_EMPL_DepartmentDId",
                table: "EMPL",
                column: "DepartmentDId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMPL");

            migrationBuilder.DropTable(
                name: "DEPARTMENT");
        }
    }
}
