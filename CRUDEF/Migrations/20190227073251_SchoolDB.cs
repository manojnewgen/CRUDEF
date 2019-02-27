using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDEF.Migrations
{
    public partial class SchoolDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Skills = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    TotalStudents = table.Column<int>(nullable: false),
                    Salary = table.Column<decimal>(type: "money", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
